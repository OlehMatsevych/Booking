using AutoMapper;
using Booking.Application.Constants;
using Booking.Application.Exceptions;
using Booking.Application.Helpers;
using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class ApartmentProviderService : IApartmentProviderService
    {
        private readonly IApartmentRequestRepository _repository;
        private readonly IMapper _mapper;

        public ApartmentProviderService(IApartmentRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<OperationStatus> CreateRequest(ApartmentRequestModel request)
        {
            var entity = _mapper.Map<ApartmentRequest>(request);
            if (entity == null)
            {
                throw new EmptyObjectException(ApartmentRequestErrorMessages.EmptyRequestModel);
            }
            try
            {
                await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                return new OperationStatus() { IsSuccesed = false, Message = "Error" + ex.Message };
            }

            return new OperationStatus() { IsSuccesed = true, Message = "OK 200" };
        }

        public IEnumerable<ApartmentRequestModel> GetAllRequests()
        {
            var entities = _repository.GetAll();
            if (entities == null)
            {
                throw new EmptyObjectException(ApartmentRequestErrorMessages.EmptyRequestModel);
            }
            return _mapper.Map<IEnumerable<ApartmentRequestModel>>(entities);
        }
    }
}
