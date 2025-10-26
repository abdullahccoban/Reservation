using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IWorkingRangeRepository : IRepository<WorkingRange>
{
    Task<IEnumerable<WorkingRange>> GetHotelWorkingRanges(int hotelId);
}