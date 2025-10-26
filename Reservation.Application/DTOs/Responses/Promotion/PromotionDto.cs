namespace Reservation.Application.DTOs.Responses.Promotion;

public class PromotionDto
{
    public int Id { get; set; }
    public int HotelId  { get; set; }
    public bool IsGeneral { get; set; }
    public string? User { get; set; }
}