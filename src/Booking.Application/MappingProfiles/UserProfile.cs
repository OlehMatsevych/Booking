using AutoMapper;
using Booking.Application.Models;
using Booking.Core.Entities;
using Booking.DataAccess;

namespace Booking.Application.MappingProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, ApplicationUser>();
            CreateMap<UserModel, Guest>();
            CreateMap<Guest, UserModel>();
        }
    }
}
