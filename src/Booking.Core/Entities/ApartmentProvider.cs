using Booking.Core.Common;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class ApartmentProvider: BaseEntity
    {
        public Apartment Apartment { get; set; }
        public IEnumerable<ApartmentRequest> ApartmentRequests { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
    }
}
