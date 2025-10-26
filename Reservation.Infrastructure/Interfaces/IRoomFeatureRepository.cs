using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IRoomFeatureRepository : IRepository<RoomFeature>
{
    Task<IEnumerable<RoomFeature>> GetHotelRoomFeatures(int roomId);
}