using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class PhotoRepository : GenericRepository<Photo, ReservationDbContext>, IPhotoRepository
{
    private readonly ReservationDbContext _context;

    public PhotoRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Photo>> GetHotelPhotos(int hotelId)
        => await _context.Photos.Where(i => i.HotelId == hotelId).ToListAsync();
}