using AutoMapper;
using Booking.Application.Constants;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        public async Task<Models.Apartment.ApartmentModel> CreateApartmentsAsync(Models.Apartment.ApartmentModel apartment)
        {
            var entity = _mapper.Map<Booking.Core.Entities.Apartment>(apartment);
            if (entity == null)
            {
                throw new Exception();
            }
            await _repository.AddAsync(entity);
            return apartment;
        }

        public async Task<string> DeleteApartmentsAsync(Guid id)
        {
            var entity = _repository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                throw new Exception("Not Found");
            await _repository.DeleteAsync(entity);
            var response = new
            {
                Success = true,
            };
            //TODO: Usings
            //TODO: brackets FOR THE IF
            //TODO: Integration Tests
            return JsonSerializer.Serialize(response);
        }

        public IEnumerable<Models.Apartment.ApartmentModel> GetApartments()
        {
            var apartments = _repository.GetAll(q => q.Location).AsParallel().ToList();
            if (apartments == null)
                throw new ArgumentException(ApartmentErrorMessages.EmptyList);
            return _mapper.Map<IEnumerable<Models.Apartment.ApartmentModel>>(apartments);
        }

        public IEnumerable<Models.Apartment.ApartmentModel> GetApartmentsByLocationAsync(Location location)
        {
            var apartments = _repository.GetAll(q => q.Location).Where(a => a.Location.Equals(location)).AsParallel().ToList();
            if (apartments == null)
                throw new ArgumentException(ApartmentErrorMessages.EmptyList);
            return _mapper.Map<IEnumerable<Models.Apartment.ApartmentModel>>(apartments);
        }

        public async Task<Models.Apartment.ApartmentModel> UpdateApartmentsAsync(Guid id, Models.Apartment.ApartmentModel apartment)
        {
            var entity = _repository.GetWhere(x => x.Id == id).FirstOrDefault();
            entity.Location = apartment.Location;
            return _mapper.Map<Models.Apartment.ApartmentModel>(entity);
        }
    }
}
