using Booking.Core.Common;
using System;

namespace Booking.Core.Entities
{
    public class ApartmentReview: BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
