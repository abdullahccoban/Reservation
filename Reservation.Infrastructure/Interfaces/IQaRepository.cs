using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IQaRepository : IRepository<Qa>
{
    Task<IEnumerable<Qa>> GetHotelQas(int hotelId);
}