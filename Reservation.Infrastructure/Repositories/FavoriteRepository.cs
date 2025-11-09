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
    
    public async Task<bool> IsFavorite(int id, string userId)
        => await _context.Favorites.AnyAsync(i => i.HotelId == id && i.UserId == userId);

    public async Task RemoveFavorite(int hotelId, string userId)
    {
        var favorite = _context.Favorites.FirstOrDefault(i => i.HotelId == hotelId && i.UserId == userId);
        if (favorite == null) throw new KeyNotFoundException();
        _context.Favorites.Remove(favorite);
        await _context.SaveChangesAsync();
    }
}