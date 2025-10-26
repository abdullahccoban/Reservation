using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class RoomFeatureRepository : GenericRepository<RoomFeature, ReservationDbContext>, IRoomFeatureRepository
{
    private readonly ReservationDbContext _context;

    public RoomFeatureRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoomFeature>> GetHotelRoomFeatures(int roomId)
        => await _context.RoomFeatures.Where(i => i.RoomId == roomId).ToListAsync();
}