using Booking.Application.Models.Apartment;
using Booking.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services.Apartment
{
    public interface IApartmentService
    {
        IEnumerable<Models.Apartment.ApartmentModel> GetApartments();
        Task<IEnumerable<Models.Apartment.ApartmentModel>> GetApartmentsByLocationAsync(Location location);
        Task<Models.Apartment.ApartmentModel> CreateApartmentsAsync(Models.Apartment.ApartmentModel apartment);
        Task<Models.Apartment.ApartmentModel> UpdateApartmentsAsync(string id, Models.Apartment.ApartmentModel apartment);
        Task DeleteApartmentsAsync(string id);
    }
}
