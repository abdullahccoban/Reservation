namespace Reservation.Application.DTOs.Requests.Hotel;

public class UpdateHotelRequestDto
{
    public required int Id { get; set;  }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DailyCapacity { get; set; }
}