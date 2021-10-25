using Booking.Core.Entities;
using Booking.DataAccess.Persistence;

namespace Booking.DataAccess.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(BookingContext context) : base(context)
        { }
    }
}
