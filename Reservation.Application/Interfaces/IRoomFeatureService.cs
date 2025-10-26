using Reservation.Application.DTOs.Requests.Room;
using Reservation.Application.DTOs.Requests.RoomFeature;
using Reservation.Application.DTOs.Responses.Room;
using Reservation.Application.DTOs.Responses.RoomFeature;

namespace Reservation.Application.Interfaces;

public interface IRoomFeatureService
{
    Task CreateRoomFeatureAsync(CreateRoomFeatureRequestDto request);
    Task UpdateRoomFeatureAsync(UpdateRoomFeatureRequestDto request);
    Task RemoveRoomFeatureAsync(int id);
    Task<List<RoomFeatureDto>> GetAllRoomFeaturesAsync();
    Task<RoomFeatureDto> GetRoomFeatureById(int id);
    Task<List<RoomFeatureDto>> GetHotelRoomFeaturesAsync(int roomId);
}