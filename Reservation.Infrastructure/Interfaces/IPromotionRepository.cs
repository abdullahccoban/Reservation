using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IPromotionRepository : IRepository<Promotion>
{
    Task<IEnumerable<Promotion>> GetHotelPromotions(int hotelId);
}