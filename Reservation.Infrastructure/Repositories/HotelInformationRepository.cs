using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class HotelInformationRepository : GenericRepository<HotelInformation, ReservationDbContext>, IHotelInformationRepository
{
    private readonly  ReservationDbContext _context;
    public HotelInformationRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<HotelInformation>> GetHotelInformations(int hotelId) 
        => await _context.HotelInformations.Where(i => i.HotelId == hotelId).ToListAsync();
    
}