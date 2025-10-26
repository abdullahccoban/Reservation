namespace Reservation.Application.DTOs.Requests.Promotion;

public class CreatePromotionRequestDto
{
    public int HotelId  { get; set; }
    public bool IsGeneral { get; set; }
    public string? User { get; set; }
}