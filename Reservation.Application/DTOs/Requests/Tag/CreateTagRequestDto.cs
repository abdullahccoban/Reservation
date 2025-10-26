namespace Reservation.Application.DTOs.Requests.Tag;

public class CreateTagRequestDto
{
    public int HotelId  { get; set; }
    public required string Tag { get; set; }
}