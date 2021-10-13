using Booking.Core.Common;
using System;

namespace Booking.Core.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Apartment Apartment { get; set; }
        public Room Room { get; set; }
    }
}
