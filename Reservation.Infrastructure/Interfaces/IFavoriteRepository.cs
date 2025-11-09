using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IFavoriteRepository : IRepository<Favorite>
{
    Task<bool> IsFavorite(int id, string userId);
    Task<IEnumerable<Favorite>> GetFavorites(string userId);
    Task RemoveFavorite(int hotelId, string userId);

}