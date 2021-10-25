using AutoMapper;
using Booking.Application.Constants;
using Booking.Application.Helpers;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentEntity = Booking.Core.Entities.Apartment;
using ApartmentModel = Booking.Application.Models.Apartment.ApartmentModel;

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
        public async Task<ApartmentModel> CreateApartmentsAsync(ApartmentModel apartment)
        {
            var entity = _mapper.Map<ApartmentEntity>(apartment);
            if (entity == null)
            {
                throw new Exception();
            }
            await _repository.AddAsync(entity);
            return apartment;
        }

        public async Task<OperationStatus> DeleteApartmentsAsync(Guid id)
        {
            var entity = _repository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found");
            }
            await _repository.DeleteAsync(entity);

            //TODO: Integration Tests
            return new OperationStatus() {IsSuccesed=true, Message="OK 200" };
        }

        public IEnumerable<ApartmentModel> GetApartments()
        {
            var apartments = _repository.GetAll(q => q.Location).AsParallel().ToList();
            if (apartments == null)
            {
                throw new ArgumentException(ApartmentErrorMessages.EmptyList);
            }
            return _mapper.Map<IEnumerable<ApartmentModel>>(apartments);
        }

        public IEnumerable<ApartmentModel> GetApartmentsByLocationAsync(Location location)
        {
            //var apartments = _repository.GetAll(q => q.Location).Where(a => a.Location.Equals(location)).AsParallel().ToList();
            var apartments = _repository.GetWhere(x=>x.Location.Id == location.Id);
            if (apartments == null)
            {
                throw new ArgumentException(ApartmentErrorMessages.EmptyList);
            }
            return _mapper.Map<IEnumerable<ApartmentModel>>(apartments);
        }

        public async Task<Models.Apartment.ApartmentModel> UpdateApartmentsAsync(Guid id, Models.Apartment.ApartmentModel apartment)
        {
            var entity = _repository.GetWhere(x => x.Id == id).FirstOrDefault();
            entity.Location = apartment.Location;
            return _mapper.Map<ApartmentModel>(entity);
        }
    }
}
