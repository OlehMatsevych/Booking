using Booking.Core.Entities;
using Booking.DataAccess.Persistence;
using System;

namespace Booking.DataAccess.Repositories
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(BookingContext context) : base(context)
        { }

        public void Dispose()
        {
            
        }
    }
}
