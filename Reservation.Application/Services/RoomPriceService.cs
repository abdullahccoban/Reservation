using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.RoomPrice;
using Reservation.Application.DTOs.Responses.RoomPrice;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class RoomPriceService : IRoomPriceService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IRoomPriceRepository _repo;

    public RoomPriceService(IUnitOfWork uow, IMapper mapper, IRoomPriceRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateRoomPriceAsync(CreateRoomPriceRequestDto request)
    {
        var room = new RoomPriceDomain(request.RoomId, request.Price, request.StartDate, request.EndDate);
        await _uow.GetRepository<RoomPrice>().AddAsync(_mapper.Map<RoomPrice>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateRoomPriceAsync(UpdateRoomPriceRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingRoomPrice = await _uow.GetRepository<RoomPrice>().GetByIdAsync(request.Id);
        if (existingRoomPrice == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<RoomPriceDomain>(existingRoomPrice);
        domain.Update(request.Price, request.StartDate, request.EndDate);

        _mapper.Map(domain, existingRoomPrice);
        _uow.GetRepository<RoomPrice>().Update(existingRoomPrice);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveRoomPriceAsync(int id)
    {
        var existingRoomPrice = await _uow.GetRepository<RoomPrice>().GetByIdAsync(id);
        if (existingRoomPrice == null) throw new KeyNotFoundException();
        _uow.GetRepository<RoomPrice>().Delete(existingRoomPrice);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<RoomPriceDto>> GetAllRoomPricesAsync()
    {
        var rooms = await _uow.GetRepository<RoomPrice>().GetAllAsync();
        return _mapper.Map<List<RoomPriceDto>>(rooms);
    }

    public async Task<RoomPriceDto> GetRoomPriceById(int id)
    {
        var existingRoomPrice = await _uow.GetRepository<RoomPrice>().GetByIdAsync(id);
        if (existingRoomPrice == null) throw new KeyNotFoundException();
        
        return _mapper.Map<RoomPriceDto>(existingRoomPrice);
    }

    public async Task<List<RoomPriceDto>> GetHotelRoomPricesAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelRoomPrices(hotelId);
        return _mapper.Map<List<RoomPriceDto>>(rooms);
    }
}