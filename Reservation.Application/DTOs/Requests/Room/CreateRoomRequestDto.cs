namespace Reservation.Application.DTOs.Requests.Room;

public class CreateRoomRequestDto
{
    public int HotelId { get; set; }
    public required string RoomType { get; set; }
    public int Capacity { get; set; }
    public int Count { get; set; }
}