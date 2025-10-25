using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class HotelRepository : GenericRepository<Hotel, ReservationDbContext>, IHotelRepository
{
    private readonly  ReservationDbContext _context;
    public HotelRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<Hotel> GetBaseQuery()
    {
        return _context.Hotels.AsNoTracking();
    }
}
