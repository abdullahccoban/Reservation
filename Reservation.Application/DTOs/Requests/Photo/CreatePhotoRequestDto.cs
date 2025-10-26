namespace Reservation.Application.DTOs.Requests.Photo;

public class CreatePhotoRequestDto
{
    public int HotelId { get; set; }
    public required string PhotoPath { get; set; }
}