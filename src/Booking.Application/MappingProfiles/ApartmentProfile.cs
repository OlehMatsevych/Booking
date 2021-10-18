using AutoMapper;
using Booking.Application.Models.Apartment;

namespace Booking.Application.MappingProfiles
{
    public class ApartmentProfile:Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Booking.Core.Entities.Apartment, ApartmentModel>();
            CreateMap<ApartmentModel, Booking.Core.Entities.Apartment>();
        }
    }
}
