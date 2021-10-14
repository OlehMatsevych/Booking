using Booking.Core.Common;
using System;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class ApartmentProvider: BaseEntity, IChangeEntity
    {
        public Apartment Apartment { get; set; }
        public IEnumerable<ApartmentRequest> ApartmentRequests { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
