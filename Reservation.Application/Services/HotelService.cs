using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Hotel;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Services;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public HotelService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task CreateHotelAsync(CreateHotelRequestDto request)
    {
        var hotel = new HotelDomain(request.Name, request.Description, request.DailyCapacity);
        await _uow.GetRepository<Hotel>().AddAsync(_mapper.Map<Hotel>(hotel));
        await _uow.SaveChangesAsync();
    }
    
    public async Task UpdateHotelAsync(UpdateHotelRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingHotel = await _uow.GetRepository<Hotel>().GetByIdAsync(request.Id);
        if (existingHotel == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<HotelDomain>(existingHotel);
        domain.Update(request.Name, request.Description, request.DailyCapacity);

        _mapper.Map(domain, existingHotel);
        _uow.GetRepository<Hotel>().Update(existingHotel);
        
        await _uow.SaveChangesAsync();
    }
}