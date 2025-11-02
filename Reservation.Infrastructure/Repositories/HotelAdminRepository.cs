using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class HotelAdminRepository : GenericRepository<HotelAdmin, ReservationDbContext>, IHotelAdminRepository
{
    private readonly  ReservationDbContext _context;
    public HotelAdminRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<HotelAdmin>> GetHotelAdmins(int hotelId) 
        => await _context.HotelAdmins.Where(i => i.HotelId == hotelId).ToListAsync();
    
    public async Task<IEnumerable<HotelAdmin>> GetAdminHotels(string userEmail)
        => await _context.HotelAdmins.Where(i => i.UserEmail == userEmail).ToListAsync();
}