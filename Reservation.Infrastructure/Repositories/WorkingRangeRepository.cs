using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class WorkingRangeRepository : GenericRepository<WorkingRange, ReservationDbContext>, IWorkingRangeRepository
{
    private readonly ReservationDbContext _context;

    public WorkingRangeRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkingRange>> GetHotelWorkingRanges(int hotelId)
        => await _context.WorkingRanges.Where(i => i.HotelId == hotelId).ToListAsync();
}