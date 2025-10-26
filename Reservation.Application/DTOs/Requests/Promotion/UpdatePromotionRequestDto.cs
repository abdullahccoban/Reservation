namespace Reservation.Application.DTOs.Requests.Promotion;

public class UpdatePromotionRequestDto
{
    public int Id { get; set; }
    public int HotelId  { get; set; }
    public bool IsGeneral { get; set; }
    public string? User { get; set; }
}