using Booking.Core.Common;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class Guest: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Payment Payment { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<Apartment> Apartments { get; set; }

    }
}
