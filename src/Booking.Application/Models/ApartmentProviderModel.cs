using Booking.Core.Entities;
using Booking.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using ApartmentModel = Booking.Core.Entities.Apartment;
namespace Booking.Application.Models
{
    public class ApartmentProviderModel: BaseModel
    {
        public ApartmentModel Apartment { get; set; }
        public IEnumerable<ApartmentRequestModel> ApartmentRequests { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
    }
}
