using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IQaRepository : IRepository<Qa>
{
    Task<IEnumerable<Qa>> GetHotelQas(int hotelId);
    Task<IEnumerable<Qa>> TakeThreeQas(int hotelId);
    Task<IEnumerable<Qa>> GetAnsweredQuestions(int hotelId);
}