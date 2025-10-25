using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IHotelRepository : IRepository<Hotel>
{
    IQueryable<Hotel> GetBaseQuery();

}