namespace Reservation.Application.DTOs.Requests.Favorite;

public class AddFavoriteRequestDto
{
    public int HotelId { get; set; }
    public required string UserId { get; set; }
}