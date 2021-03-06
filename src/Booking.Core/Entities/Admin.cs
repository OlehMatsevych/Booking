using Booking.Core.Attributes;
using Booking.Core.Common;
using System;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class Admin: BaseEntity, IChangeEntity
    {
        public string Name { get; set; }

        [EmailValidation]
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Apartment> Apartments { get; set; }
        public IEnumerable<ApartmentRequest> ApartmentRequests { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
