namespace Reservation.Application.DTOs.Requests.HotelInformation;

public class UpdateHotelInformationRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string? Description { get; set; }
}