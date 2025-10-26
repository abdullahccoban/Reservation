namespace Reservation.Application.DTOs.Responses.RoomPrice;

public class RoomPriceDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}