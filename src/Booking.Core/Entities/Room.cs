using Booking.Core.Common;

namespace Booking.Core.Entities
{
    public class Room: BaseEntity
    {
        public bool IsFree { get; set; }
        public Reservation Reservation { get; set; }
        public Apartment Apartment { get; set; }
        public RoomDetails RoomDetails { get; set; }
    }
}
