using Reservation.Application.DTOs.Requests.Favorite;
using Reservation.Application.DTOs.Responses.Favorite;

namespace Reservation.Application.Interfaces;

public interface IFavoriteService
{
    Task AddFavoriteAsync(AddFavoriteRequestDto request);
    Task RemoveFavoriteAsync(int id);
    Task<List<FavoritesResponseDto>> GetFavoritesAsync(string userId);
}