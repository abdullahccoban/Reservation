using GenericInfra;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Infrastructure.Repositories;

public class HotelInformationRepository : GenericRepository<HotelInformation, ReservationDbContext>, IHotelInformationRepository
{
    public HotelInformationRepository(ReservationDbContext context) : base(context)
    {
    }
}