using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class PromotionRepository : GenericRepository<Promotion, ReservationDbContext>, IPromotionRepository
{
    private readonly ReservationDbContext _context;

    public PromotionRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Promotion>> GetHotelPromotions(int hotelId)
        => await _context.Promotions.Where(i => i.HotelId == hotelId).ToListAsync();
}