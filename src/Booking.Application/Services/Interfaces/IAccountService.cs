using Booking.Application.Models;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> LoginAsync(UserModel user);
        Task<string> CreateAsync(UserModel user);
    }
}
