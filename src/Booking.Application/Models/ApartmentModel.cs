using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Models.Apartment
{
    public class ApartmentModel: BaseModel
    {
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
    }
}
