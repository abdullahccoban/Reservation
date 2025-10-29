using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.HotelAdmin;
using Reservation.Application.DTOs.Responses.HotelAdmin;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class HotelAdminService : IHotelAdminService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IHotelAdminRepository _repo;

    public HotelAdminService(IUnitOfWork uow, IMapper mapper, IHotelAdminRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateHotelAdminAsync(CreateHotelAdminRequestDto request)
    {
        var hotelInfo = new HotelAdminDomain(request.HotelId, request.UserEmail);
        await _uow.GetRepository<HotelAdmin>().AddAsync(_mapper.Map<HotelAdmin>(hotelInfo));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateHotelAdminAsync(UpdateHotelAdminRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingHotelInfo = await _uow.GetRepository<HotelAdmin>().GetByIdAsync(request.Id);
        if (existingHotelInfo == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<HotelAdminDomain>(existingHotelInfo);
        domain.Update(request.UserEmail);

        _mapper.Map(domain, existingHotelInfo);
        _uow.GetRepository<HotelAdmin>().Update(existingHotelInfo);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveHotelAdminAsync(int id)
    {
        var existingHotelInfo = await _uow.GetRepository<HotelAdmin>().GetByIdAsync(id);
        if (existingHotelInfo == null) throw new KeyNotFoundException();
        _uow.GetRepository<HotelAdmin>().Delete(existingHotelInfo);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<HotelAdminDto>> GetAllHotelAdminsAsync()
    {
        var hotelInfos = await _uow.GetRepository<HotelAdmin>().GetAllAsync();
        return _mapper.Map<List<HotelAdminDto>>(hotelInfos);
    }

    public async Task<HotelAdminDto> GetHotelAdminByIdAsync(int id)
    {
        var existingHotelInfo = await _uow.GetRepository<HotelAdmin>().GetByIdAsync(id);
        if (existingHotelInfo == null) throw new KeyNotFoundException();
        
        return _mapper.Map<HotelAdminDto>(existingHotelInfo);
    }

    public async Task<List<HotelAdminDto>> GetHotelAdminsAsync(string userEmail)
    {
        var hotelInfos = await _repo.GetAdminHotels(userEmail);
        return _mapper.Map<List<HotelAdminDto>>(hotelInfos);
    }
}