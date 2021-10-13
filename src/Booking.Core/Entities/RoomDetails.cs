using Booking.Core.Common;
using Booking.Core.Enums;

namespace Booking.Core.Entities
{
    public class RoomDetails: BaseEntity
    {
        public float Price { get; set; }
        public RoomType RoomType { get; set; }
        public int Area { get; set; }
        public int RoomsAmount { get; set; }
    }
}
