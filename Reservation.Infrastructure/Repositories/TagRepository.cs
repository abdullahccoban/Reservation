using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class TagRepository : GenericRepository<Tag, ReservationDbContext>, ITagRepository
{
    private readonly ReservationDbContext _context;

    public TagRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tag>> GetHotelTags(int hotelId)
        => await _context.Tags.Where(i => i.HotelId == hotelId).ToListAsync();
}