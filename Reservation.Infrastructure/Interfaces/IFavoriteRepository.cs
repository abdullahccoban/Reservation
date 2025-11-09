using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IFavoriteRepository : IRepository<Favorite>
{
    Task<IEnumerable<Favorite>> GetFavorites(string userId);
}