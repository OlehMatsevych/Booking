using Booking.Core.Entities;
using Booking.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.DataAccess.Repositories
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(BookingContext context): base(context)
        {}
    }
}
