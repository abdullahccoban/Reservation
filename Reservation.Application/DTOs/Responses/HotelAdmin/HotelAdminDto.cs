namespace Reservation.Application.DTOs.Responses.HotelAdmin;

public class HotelAdminDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string UserEmail { get; set; }
}