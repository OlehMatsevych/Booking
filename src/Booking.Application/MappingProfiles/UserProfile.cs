using AutoMapper;
using Booking.Application.Models;
using Booking.DataAccess;

namespace Booking.Application.MappingProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserModel>();
            CreateMap<UserModel, ApplicationUser>();
        }
    }
}
