using AutoMapper;
using Booking.Application.Models;
using Booking.Core.Entities;

namespace Booking.Application.MappingProfiles
{
    public class ApartmentProviderProfile : Profile
    {
        public ApartmentProviderProfile()
        {
            CreateMap<ApartmentProvider, ApartmentProviderModel>();
            CreateMap<ApartmentProviderModel, ApartmentProvider>();
        }
    }
}
