namespace Reservation.Application.DTOs.Requests.HotelAdmin;

public class UpdateHotelAdminRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string UserEmail { get; set; }
}