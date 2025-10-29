namespace Reservation.Application.DTOs.Requests.HotelAdmin;

public class CreateHotelAdminRequestDto
{
    public int HotelId { get; set; }
    public required string UserEmail { get; set; }
}