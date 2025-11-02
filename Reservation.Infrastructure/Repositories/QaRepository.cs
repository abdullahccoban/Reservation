using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class QaRepository : GenericRepository<Qa, ReservationDbContext>, IQaRepository
{
    private readonly ReservationDbContext _context;

    public QaRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Qa>> GetHotelQas(int hotelId)
        => await _context.Qas.Where(i => i.HotelId == hotelId).ToListAsync();
}