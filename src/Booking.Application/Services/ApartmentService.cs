using AutoMapper;
using Booking.Application.Models.Apartment;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Apartment
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<Models.Apartment.ApartmentModel> CreateApartmentsAsync(Models.Apartment.ApartmentModel apartment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteApartmentsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Apartment.ApartmentModel> GetApartments()
        {
            var apartments = _repository.GetAll(q=>q.Location).AsParallel().ToList();
            return _mapper.Map<IEnumerable<Models.Apartment.ApartmentModel>>(apartments);
        }

        public Task<IEnumerable<Models.Apartment.ApartmentModel>> GetApartmentsByLocationAsync(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Apartment.ApartmentModel> UpdateApartmentsAsync(string id, Models.Apartment.ApartmentModel apartment)
        {
            throw new NotImplementedException();
        }
    }
}
