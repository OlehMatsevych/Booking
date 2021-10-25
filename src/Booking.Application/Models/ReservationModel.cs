using System;

namespace Booking.Application.Models
{
    public class ReservationModel: BaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ApartmentId { get; set; }
        public Guid RoomId { get; set; }
    }
}
