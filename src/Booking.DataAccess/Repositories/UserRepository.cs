using Booking.Core.Entities;
using Booking.DataAccess.Persistence;

namespace Booking.DataAccess.Repositories
{
    public class UserRepository : Repository<Guest>, IUserRepository
    {
        public UserRepository(BookingContext context) : base(context)
        { }
    }
}
