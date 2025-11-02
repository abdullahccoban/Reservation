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
}