using AutoMapper;
using Booking.Application.Models.Apartment;
using Booking.Core.Entities;

namespace Booking.Application.MappingProfiles
{
    public class ApartmentProfile:Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Apartment, ApartmentModel>();
            CreateMap<ApartmentModel, Apartment>();
        }
    }
}
