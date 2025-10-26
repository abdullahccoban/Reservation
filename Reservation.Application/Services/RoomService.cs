using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Room;
using Reservation.Application.DTOs.Responses.Room;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class RoomService : IRoomService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IRoomRepository _repo;

    public RoomService(IUnitOfWork uow, IMapper mapper, IRoomRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateRoomAsync(CreateRoomRequestDto request)
    {
        var room = new RoomDomain(request.HotelId, request.RoomType, request.Capacity, request.Count);
        await _uow.GetRepository<Room>().AddAsync(_mapper.Map<Room>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateRoomAsync(UpdateRoomRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingRoom = await _uow.GetRepository<Room>().GetByIdAsync(request.Id);
        if (existingRoom == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<RoomDomain>(existingRoom);
        domain.Update(request.RoomType, request.Capacity, request.Count);

        _mapper.Map(domain, existingRoom);
        _uow.GetRepository<Room>().Update(existingRoom);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveRoomAsync(int id)
    {
        var existingRoom = await _uow.GetRepository<Room>().GetByIdAsync(id);
        if (existingRoom == null) throw new KeyNotFoundException();
        _uow.GetRepository<Room>().Delete(existingRoom);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await _uow.GetRepository<Room>().GetAllAsync();
        return _mapper.Map<List<RoomDto>>(rooms);
    }

    public async Task<RoomDto> GetRoomById(int id)
    {
        var existingRoom = await _uow.GetRepository<Room>().GetByIdAsync(id);
        if (existingRoom == null) throw new KeyNotFoundException();
        
        return _mapper.Map<RoomDto>(existingRoom);
    }

    public async Task<List<RoomDto>> GetHotelRoomsAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelRooms(hotelId);
        return _mapper.Map<List<RoomDto>>(rooms);
    }
}