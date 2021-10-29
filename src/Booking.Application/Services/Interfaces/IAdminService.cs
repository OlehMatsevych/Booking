using Booking.Application.Helpers;
using Booking.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface IAdminService
    {
        Task<OperationStatus> ApproveRequest(ApartmentRequestModel request);
        Task<OperationStatus> BlockUser(UserModel user);

    }
}
