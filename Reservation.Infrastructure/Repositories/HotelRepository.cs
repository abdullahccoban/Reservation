using GenericInfra;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class HotelRepository : GenericRepository<Hotel, ReservationDbContext>, IHotelRepository
{
    public HotelRepository(ReservationDbContext context) : base(context)
    {
    }
}
