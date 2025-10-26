namespace Reservation.Application.DTOs.Requests.Photo;

public class UpdatePhotoRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string PhotoPath { get; set; }
    public DateTime CreatedAt { get; set; }
}