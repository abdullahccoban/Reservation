using Reservation.Application.DTOs.Responses.Hotels;

namespace Reservation.Application.DTOs.Responses.Favorite;

public class FavoritesResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int StarCount { get; set; }
}