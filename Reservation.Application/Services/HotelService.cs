using AutoMapper;
using AutoMapper.QueryableExtensions;
using GenericInfra.Core;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.DTOs.Requests.Hotel;
using Reservation.Application.DTOs.Responses;
using Reservation.Application.DTOs.Responses.Hotels;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IHotelRepository _repo;

    public HotelService(IUnitOfWork uow, IMapper mapper, IHotelRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<HotelDetailDto?> GetHotelById(int id)
    {
        return await _repo.GetBaseQuery()
            .Where(h => h.Id == id)
            .ProjectTo<HotelDetailDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<PagedResult<HotelDto>> SearchHotels(HotelSearchRequestDto request)
    {
        var query = _repo.GetBaseQuery();
        
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var search = request.SearchTerm.ToLower();
            query = query.Where(h => h.Name.ToLower().Contains(search));
        }
        
        var total = await query.CountAsync();
        
        var hotels = await query
            .OrderBy(h => h.Name)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                DailyCapacity = h.DailyCapacity,
                Country = h.Country,
                City = h.City,
                Phone = h.Phone,
                StarCount = h.StarCount ?? 5
            })
            .ToListAsync();
        
        return new PagedResult<HotelDto>
        {
            Items = hotels,
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = total
        };
    }
    
    public async Task<List<HotelDto>> GetHotelsForAdmins(string email)
    {
        var hotels = await _repo.GetBaseQuery()
            .Where(h => h.HotelAdmins.Any(ha => ha.UserEmail == email))
            .Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                DailyCapacity = h.DailyCapacity,
                Country = h.Country,
                City = h.City,
                Phone = h.Phone,
                StarCount = h.StarCount ?? 5
            })
            .ToListAsync();

        return hotels;
    }


    public async Task<List<HotelCardDto>> GetHotelCards()
    {
        var currentDate = DateTime.UtcNow.Date;
        var baseQuery = _repo.GetBaseQuery();

        var hotelCards = await baseQuery
            .Select(hotel => new HotelCardDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                AverageScore = hotel.Comments.Any() ? hotel.Comments.Average(c => c.Point) : 0,
                CommentCount = hotel.Comments.Count(),
                MinPrice = hotel.Rooms.Any() ? hotel.Rooms.SelectMany(room => room.RoomPrices).Where(price => price.StartDate <= currentDate && price.EndDate >= currentDate).Min(price => (decimal)price.Price) : 0,
                FirstPhotoPath = hotel.Photos.Any() ? hotel.Photos.OrderBy(p => p.CreatedAt).Select(p => p.PhotoPath).FirstOrDefault() : null,
                StarCount = hotel.StarCount ?? 5
            })
            .OrderBy(hotel => hotel.Id)
            .Take(10)
            .ToListAsync();
        
        return hotelCards;
    }

    public async Task CreateHotelAsync(CreateHotelRequestDto request)
    {
        var hotel = new HotelDomain(request.Name, request.Description, request.DailyCapacity, request.Country, request.City, request.Phone, request.StarCount);
        await _uow.GetRepository<Hotel>().AddAsync(_mapper.Map<Hotel>(hotel));
        await _uow.SaveChangesAsync();
    }
    
    public async Task UpdateHotelAsync(UpdateHotelRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingHotel = await _uow.GetRepository<Hotel>().GetByIdAsync(request.Id);
        if (existingHotel == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<HotelDomain>(existingHotel);
        domain.Update(request.Name, request.Description, request.DailyCapacity,  request.Country, request.City, request.Phone, request.StarCount);

        _mapper.Map(domain, existingHotel);
        _uow.GetRepository<Hotel>().Update(existingHotel);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveHotelAsync(int id)
    {
        var existingHotel = await _uow.GetRepository<Hotel>().GetByIdAsync(id);
        if (existingHotel == null) throw new KeyNotFoundException();
        _uow.GetRepository<Hotel>().Delete(existingHotel);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<HotelDto>> GetHotelsAsync()
    {
        var hotels = await _uow.GetRepository<Hotel>().GetAllAsync();
        return _mapper.Map<List<HotelDto>>(hotels);
    }

    public async Task<HotelDto> GetHotelByIdAsync(int id)
    {
        var existingHotel = await _uow.GetRepository<Hotel>().GetByIdAsync(id);
        if (existingHotel == null) throw new KeyNotFoundException();
        
        return _mapper.Map<HotelDto>(existingHotel);
    }
}