using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class RoomRepository : GenericRepository<Room, ReservationDbContext>, IRoomRepository
{
    private readonly ReservationDbContext _context;

    public RoomRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> GetHotelRooms(int hotelId)
        => await _context.Rooms.Where(i => i.HotelId == hotelId).ToListAsync();
}