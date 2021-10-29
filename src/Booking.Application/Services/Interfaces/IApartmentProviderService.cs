using Booking.Application.Helpers;
using Booking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface IApartmentProviderService
    {
        public Task<OperationStatus> CreateRequest(ApartmentRequestModel request);
        public IEnumerable<ApartmentRequestModel> GetAllRequests();
    }
}
