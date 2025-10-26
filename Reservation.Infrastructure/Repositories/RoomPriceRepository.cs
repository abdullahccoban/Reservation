using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class RoomPriceRepository : GenericRepository<RoomPrice, ReservationDbContext>, IRoomPriceRepository
{
    private readonly ReservationDbContext _context;

    public RoomPriceRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoomPrice>> GetHotelRoomPrices(int roomId)
        => await _context.RoomPrices.Where(i => i.RoomId == roomId).ToListAsync();
}