using Booking.Core.Common;
using System;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class Apartment: BaseEntity
    {
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<ApartmentProvider> ApartmentProvider { get; set; }
        public IEnumerable<ApartmentReview> Reviews { get; set; }
        public Guest Guest { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
