namespace Reservation.Application.DTOs.Responses.Hotels;

public class HotelDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DailyCapacity { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public int StarCount { get; set; }
}