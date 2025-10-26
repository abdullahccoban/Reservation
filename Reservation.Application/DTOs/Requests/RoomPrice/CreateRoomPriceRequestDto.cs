namespace Reservation.Application.DTOs.Requests.RoomPrice;

public class CreateRoomPriceRequestDto
{
    public int RoomId { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}