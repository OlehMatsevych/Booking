using Booking.Application.Helpers;
using Booking.Application.Models;
using Booking.Application.Models.Apartment;
using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services.Apartment
{
    public interface IApartmentService
    {
        IEnumerable<ApartmentModel> GetApartments();
        IEnumerable<ApartmentModel> GetApartmentsByLocationAsync(Location location);
        Task<IEnumerable<RoomModel>> GetFreeRoomByLocationAsync(Location location);
        Task<ApartmentModel> CreateApartmentsAsync(ApartmentModel apartment);
        ApartmentModel UpdateApartmentsAsync(Guid id, ApartmentModel apartment);
        Task<OperationStatus> DeleteApartmentsAsync(Guid id);
    }
}
