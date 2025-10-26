using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.HotelInformation;
using Reservation.Application.DTOs.Responses.HotelInformation;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class HotelInformationService : IHotelInformationService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IHotelInformationRepository _repo;

    public HotelInformationService(IUnitOfWork uow, IMapper mapper, IHotelInformationRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateHotelInformationAsync(CreateHotelInformationRequestDto request)
    {
        var hotelInfo = new HotelInformationDomain(request.HotelId, request.Description);
        await _uow.GetRepository<HotelInformation>().AddAsync(_mapper.Map<HotelInformation>(hotelInfo));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateHotelInformationAsync(UpdateHotelInformationRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingHotelInfo = await _uow.GetRepository<HotelInformation>().GetByIdAsync(request.Id);
        if (existingHotelInfo == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<HotelInformationDomain>(existingHotelInfo);
        domain.Update(request.Description);

        _mapper.Map(domain, existingHotelInfo);
        _uow.GetRepository<HotelInformation>().Update(existingHotelInfo);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveHotelInformationAsync(int id)
    {
        var existingHotelInfo = await _uow.GetRepository<HotelInformation>().GetByIdAsync(id);
        if (existingHotelInfo == null) throw new KeyNotFoundException();
        _uow.GetRepository<HotelInformation>().Delete(existingHotelInfo);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<HotelInformationDto>> GetAllHotelInformationsAsync()
    {
        var hotelInfos = await _uow.GetRepository<HotelInformation>().GetAllAsync();
        return _mapper.Map<List<HotelInformationDto>>(hotelInfos);
    }

    public async Task<HotelInformationDto> GetHotelInformationByIdAsync(int id)
    {
        var existingHotelInfo = await _uow.GetRepository<HotelInformation>().GetByIdAsync(id);
        if (existingHotelInfo == null) throw new KeyNotFoundException();
        
        return _mapper.Map<HotelInformationDto>(existingHotelInfo);
    }

    public async Task<List<HotelInformationDto>> GetHotelInformationsAsync(int hotelId)
    {
        var hotelInfos = await _repo.GetHotelInformations(hotelId);
        return _mapper.Map<List<HotelInformationDto>>(hotelInfos);
    }
}