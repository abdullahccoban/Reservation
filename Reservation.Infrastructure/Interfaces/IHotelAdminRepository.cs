using GenericInfra.Core;
using Reservation.Infrastructure.Context;

namespace Reservation.Infrastructure.Interfaces;

public interface IHotelAdminRepository : IRepository<HotelAdmin>
{
    Task<IEnumerable<HotelAdmin>> GetHotelAdmins(int hotelId);
    Task<IEnumerable<HotelAdmin>> GetAdminHotels(string userEmail);
}