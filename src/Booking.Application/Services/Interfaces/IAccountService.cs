using Booking.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> LoginAsync(UserModel user);
        Task CreateAsync(UserModel user);
    }
}
