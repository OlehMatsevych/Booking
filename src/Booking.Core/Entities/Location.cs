
using Booking.Core.Common;

namespace Booking.Core.Entities
{
    public class Location: BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
