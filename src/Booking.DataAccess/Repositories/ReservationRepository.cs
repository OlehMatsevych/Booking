using Booking.Core.Entities;
using Booking.DataAccess.Persistence;

namespace Booking.DataAccess.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(BookingContext context) : base(context)
        { }
    }
}
