using GenericInfra;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class CommentRepository : GenericRepository<Comment, ReservationDbContext>, ICommentRepository
{
    private readonly ReservationDbContext _context;

    public CommentRepository(ReservationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Comment>> GetHotelComments(int hotelId)
        => await _context.Comments.Where(i => i.HotelId == hotelId).ToListAsync();
    
    public async Task<IEnumerable<Comment>> TakeThreeComments(int hotelId) 
        => await _context.Comments.Where(c => c.HotelId == hotelId).OrderByDescending(c => c.Id).Take(3).ToListAsync();
    
    public async Task<int> TakeCommentCount(int hotelId) 
        => await _context.Comments.CountAsync(c => c.HotelId == hotelId);
    
    public async Task<double> GetAverageScore(int hotelId)
        => await _context.Comments.Where(c => c.HotelId == hotelId).AverageAsync(c => c.Point);
    
}