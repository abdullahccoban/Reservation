using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface ICommentRepository : IRepository<Comment>
{
    Task<IEnumerable<Comment>> GetHotelComments(int hotelId);
    Task<IEnumerable<Comment>> TakeThreeComments(int hotelId);
    Task<int> TakeCommentCount(int hotelId);
    Task<double> GetAverageScore(int hotelId);
}