using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class FavoriteRepository : GenericRepository<Favorite, ReservationDbContext>, IFavoriteRepository
{
    private readonly ReservationDbContext _context;

    public FavoriteRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Favorite>> GetFavorites(string userId)
        => await _context.Favorites.Where(i => i.UserId == userId).Include(h => h.Hotel).ToListAsync();
}