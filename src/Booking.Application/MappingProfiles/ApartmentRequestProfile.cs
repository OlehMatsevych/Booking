using AutoMapper;
using Booking.Application.Models;
using Booking.Core.Entities;

namespace Booking.Application.MappingProfiles
{
    public class ApartmentRequestProfile: Profile
    {
        public ApartmentRequestProfile()
        {
            CreateMap<ApartmentRequest, ApartmentRequestModel>();
            CreateMap<ApartmentRequestModel, ApartmentRequest>();
        }
    }
}
