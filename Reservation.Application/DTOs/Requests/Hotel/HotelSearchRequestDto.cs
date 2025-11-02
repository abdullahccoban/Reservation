namespace Reservation.Application.DTOs.Requests.Hotel;

public class HotelSearchRequestDto
{
    public string? SearchTerm { get; set; } = "";
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}