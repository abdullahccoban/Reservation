namespace Reservation.Application.DTOs.Requests.RoomFeature;

public class UpdateRoomFeatureRequestDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public required string Feature { get; set; }
}