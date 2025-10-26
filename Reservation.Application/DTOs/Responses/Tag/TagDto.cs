namespace Reservation.Application.DTOs.Responses.Tag;

public class TagDto
{
    public int Id { get; set; } 
    public int HotelId  { get; set; }
    public required string Tag { get; set; }
}