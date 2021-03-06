using Booking.Core.Entities;
using System.Collections.Generic;

namespace Booking.Application.Models
{
    public class RoomModel: BaseModel
    {
        public bool IsFree { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
    }
}
