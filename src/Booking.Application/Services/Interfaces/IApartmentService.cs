using Booking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services.Apartment
{
    public interface IApartmentService
    {
        IEnumerable<Models.Apartment.ApartmentModel> GetApartments();
        IEnumerable<Models.Apartment.ApartmentModel> GetApartmentsByLocationAsync(Location location);
        Task<Models.Apartment.ApartmentModel> CreateApartmentsAsync(Models.Apartment.ApartmentModel apartment);
        Task<Models.Apartment.ApartmentModel> UpdateApartmentsAsync(Guid id, Models.Apartment.ApartmentModel apartment);
        Task DeleteApartmentsAsync(Guid id);
    }
}
