namespace Reservation.Application.DTOs.Responses.Photo;

public class PhotoDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string PhotoPath { get; set; }
    public DateTime CreatedAt { get; set; }
}