using Booking.Core.Entities;
using Booking.DataAccess.Persistence;

namespace Booking.DataAccess.Repositories
{
    public class ApartmentRequestRepository : Repository<ApartmentRequest>, IApartmentRequestRepository
    {
        public ApartmentRequestRepository(BookingContext context) : base(context)
        { }
    }
}
