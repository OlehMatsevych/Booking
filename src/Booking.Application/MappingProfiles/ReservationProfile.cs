using AutoMapper;
using Booking.Application.Models;
using Booking.Core.Entities;

namespace Booking.Application.MappingProfiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationModel>();
            CreateMap<ReservationModel, Reservation>();
        }
    }
}
