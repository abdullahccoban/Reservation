using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IRoomPriceRepository : IRepository<RoomPrice>
{
    Task<IEnumerable<RoomPrice>> GetHotelRoomPrices(int roomId);
}