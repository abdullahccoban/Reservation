using Reservation.Application.DTOs.Requests.RoomPrice;
using Reservation.Application.DTOs.Responses.RoomPrice;

namespace Reservation.Application.Interfaces;

public interface IRoomPriceService
{
    Task CreateRoomPriceAsync(CreateRoomPriceRequestDto request);
    Task UpdateRoomPriceAsync(UpdateRoomPriceRequestDto request);
    Task RemoveRoomPriceAsync(int id);
    Task<List<RoomPriceDto>> GetAllRoomPricesAsync();
    Task<RoomPriceDto> GetRoomPriceById(int id);
    Task<List<RoomPriceDto>> GetHotelRoomPricesAsync(int roomId);
}