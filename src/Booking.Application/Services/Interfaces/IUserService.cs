using Booking.Application.Helpers;
using Booking.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<OperationStatus> AddReservation(ReservationModel reservation);
        Task<OperationStatus> CancelReservation(Guid reservationId);
        Task<OperationStatus> DeleteUserAsync(Guid id);
    }
}
