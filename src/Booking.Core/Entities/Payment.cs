using Booking.Core.Common;

namespace Booking.Core.Entities
{
    public class Payment: BaseEntity
    {
        public string Deal { get; set; }
        public string PaymantMethod { get; set; }
    }
}
