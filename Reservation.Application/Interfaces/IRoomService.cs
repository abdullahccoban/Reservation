using Reservation.Application.DTOs.Requests.Room;
using Reservation.Application.DTOs.Responses.Room;

namespace Reservation.Application.Interfaces;

public interface IRoomService
{
    Task CreateRoomAsync(CreateRoomRequestDto request);
    Task UpdateRoomAsync(UpdateRoomRequestDto request);
    Task RemoveRoomAsync(int id);
    Task<List<RoomDto>> GetAllRoomsAsync();
    Task<RoomDto> GetRoomById(int id);
    Task<List<RoomDto>> GetHotelRoomsAsync(int hotelId);
}