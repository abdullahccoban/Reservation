namespace Reservation.Application.DTOs.Requests.RoomFeature;

public class CreateRoomFeatureRequestDto
{
    public int RoomId { get; set; }
    public required string Feature { get; set; }
}