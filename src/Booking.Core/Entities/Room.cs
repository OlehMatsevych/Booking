using Booking.Core.Common;
using System.Collections.Generic;

namespace Booking.Core.Entities
{
    public class Room: BaseEntity
    {
        public bool IsFree { get; set; }
        public IEnumerable<Reservation> Reservation { get; set; }
        public Apartment Apartment { get; set; }
        public RoomDetails RoomDetails { get; set; }
    }
}
