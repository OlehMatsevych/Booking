using AutoMapper;
using Booking.Application.Models;
using Booking.Core.Entities;

namespace Booking.Application.MappingProfiles
{
    public class AdminProfile: Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminModel>();
            CreateMap<AdminModel, Admin>();
        }
    }
}
