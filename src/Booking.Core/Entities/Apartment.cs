using Booking.Core.Common;
using Booking.Core.Structs;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class Apartment: BaseEntity
    {
        public Location Location { get; set; }
        IEnumerable<Room> Rooms { get; set; }
        ApartmentProvider ApartmentProvider { get; set; }
        IEnumerable<ApartmentReview> Reviews { get; set; }
        IEnumerable<Reservation> Reservations { get; set; }
    }
}
