namespace Reservation.Application.DTOs.Requests.Favorite;

public class RemoveFavoriteRequestDto
{
    public int HotelId { get; set; }
    public required string UserId { get; set; }
}