using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.RoomFeature;
using Reservation.Application.DTOs.Responses.RoomFeature;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class RoomFeatureService : IRoomFeatureService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IRoomFeatureRepository _repo;

    public RoomFeatureService(IUnitOfWork uow, IMapper mapper, IRoomFeatureRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateRoomFeatureAsync(CreateRoomFeatureRequestDto request)
    {
        var room = new RoomFeatureDomain(request.RoomId, request.Feature);
        await _uow.GetRepository<RoomFeature>().AddAsync(_mapper.Map<RoomFeature>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateRoomFeatureAsync(UpdateRoomFeatureRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingRoomFeature = await _uow.GetRepository<RoomFeature>().GetByIdAsync(request.Id);
        if (existingRoomFeature == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<RoomFeatureDomain>(existingRoomFeature);
        domain.Update(request.Feature);

        _mapper.Map(domain, existingRoomFeature);
        _uow.GetRepository<RoomFeature>().Update(existingRoomFeature);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveRoomFeatureAsync(int id)
    {
        var existingRoomFeature = await _uow.GetRepository<RoomFeature>().GetByIdAsync(id);
        if (existingRoomFeature == null) throw new KeyNotFoundException();
        _uow.GetRepository<RoomFeature>().Delete(existingRoomFeature);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<RoomFeatureDto>> GetAllRoomFeaturesAsync()
    {
        var rooms = await _uow.GetRepository<RoomFeature>().GetAllAsync();
        return _mapper.Map<List<RoomFeatureDto>>(rooms);
    }

    public async Task<RoomFeatureDto> GetRoomFeatureById(int id)
    {
        var existingRoomFeature = await _uow.GetRepository<RoomFeature>().GetByIdAsync(id);
        if (existingRoomFeature == null) throw new KeyNotFoundException();
        
        return _mapper.Map<RoomFeatureDto>(existingRoomFeature);
    }

    public async Task<List<RoomFeatureDto>> GetHotelRoomFeaturesAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelRoomFeatures(hotelId);
        return _mapper.Map<List<RoomFeatureDto>>(rooms);
    }
}