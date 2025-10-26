namespace Reservation.Application.DTOs.Requests.HotelInformation;

public class CreateHotelInformationRequestDto
{
    public int HotelId { get; set; }
    public string? Description { get; set; }
}