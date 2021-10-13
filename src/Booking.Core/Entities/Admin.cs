using Booking.Core.Common;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class Admin: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Apartment> Apartments { get; set; }
        public IEnumerable<ApartmentRequest> ApartmentRequests { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
    }
}
