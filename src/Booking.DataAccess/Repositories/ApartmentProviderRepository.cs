using Booking.Core.Entities;
using Booking.DataAccess.Persistence;

namespace Booking.DataAccess.Repositories
{
    public class ApartmentProviderRepository: Repository<ApartmentProvider>, IApartmentProviderRepository
    {
        public ApartmentProviderRepository(BookingContext context) : base(context)
        { }
    }
}
