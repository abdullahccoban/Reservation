using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IHotelInformationRepository : IRepository<HotelInformation>
{
    Task<IEnumerable<HotelInformation>> GetHotelInformations(int hotelId);
}