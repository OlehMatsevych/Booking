using AutoMapper;
using Booking.Application.Models;
using Booking.Core.Entities;

namespace Booking.Application.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomModel>();
            CreateMap<RoomModel, Room>();
        }
    }
}
