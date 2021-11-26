using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface ICarService
    {
        Task<string> GetAllAsync();
    }
}
