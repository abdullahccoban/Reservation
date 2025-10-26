namespace Reservation.Application.DTOs.Responses.RoomFeature;

public class RoomFeatureDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public required string Feature { get; set; }
}