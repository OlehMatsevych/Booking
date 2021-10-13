using Booking.Core.Common;

namespace Booking.Core.Entities
{
    public class ApartmentRequest: BaseEntity
    {
        public bool IsApproved { get; set; }
        public string Message { get; set; }
    }
}
