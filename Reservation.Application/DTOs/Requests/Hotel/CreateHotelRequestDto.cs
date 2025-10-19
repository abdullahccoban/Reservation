namespace Reservation.Application.DTOs.Requests.Hotel;

public class CreateHotelRequestDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int DailyCapacity { get; set; }
}