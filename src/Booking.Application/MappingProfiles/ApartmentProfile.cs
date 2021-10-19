using AutoMapper;
using Booking.Application.Models.Apartment;

namespace Booking.Application.MappingProfiles
{
    public class ApartmentProfile:Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Core.Entities.Apartment, ApartmentModel>();
            CreateMap<ApartmentModel, Core.Entities.Apartment>();
        }
    }
}
