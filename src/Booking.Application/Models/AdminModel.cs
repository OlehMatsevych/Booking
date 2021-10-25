using Booking.Core.Entities;
using System.Collections.Generic;
using ApartmentEntity = Booking.Core.Entities.Apartment;

namespace Booking.Application.Models
{
    public class AdminModel: BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<ApartmentEntity> Apartments { get; set; }
        public IEnumerable<ApartmentRequest> ApartmentRequests { get; set; }
    }
}
