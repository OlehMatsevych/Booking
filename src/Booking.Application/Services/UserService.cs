using AutoMapper;
using Booking.Application.Constants;
using Booking.Application.Exceptions;
using Booking.Application.Helpers;
using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApartmentEntity = Booking.Core.Entities.Apartment;

namespace Booking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper, IReservationRepository reservationRepository, IMemoryCache cache)
        {
            _repository = repository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<OperationStatus> AddReservation(ReservationModel reservation)
        {
            var entity = _mapper.Map<Reservation>(reservation);
            if(entity == null)
            {
                throw new EmptyObjectException(ReservationErrorMessages.ReservationNotFoundException);
            }
            _cache.Set(entity.Id, entity, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            });
            await _reservationRepository.AddAsync(entity);

            return new OperationStatus() { IsSuccesed = true, Message = "OK 200" };
        }

        public async Task<OperationStatus> CancelReservation(Guid reservationId)
        { 
            var entity = _reservationRepository.GetWhere(x => x.Id == reservationId).FirstOrDefault();
            if (entity == null)
            {
                throw new EmptyObjectException(ReservationErrorMessages.ReservationNotFoundException);
            }
            await _reservationRepository.DeleteAsync(entity);

            return new OperationStatus() { IsSuccesed = true, Message = "OK 200" };
        }

        public async Task<OperationStatus> DeleteUserAsync(Guid id)
        {
            var user = _repository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new EmptyObjectException(ReservationErrorMessages.ReservationNotFoundException);
            }
            await _repository.DeleteAsync(user);

            return new OperationStatus() { IsSuccesed = true, Message = "OK 200" };
        }

        public async Task<List<ReservationModel>> GetHistory()
        {
            var historyList = new List<ReservationModel>();
            var keys = _cache.GetKeys();
            foreach (var key in keys)
            {
                if (key != null)
                {
                    var temp = _cache.Get(key);
                    if (temp is Reservation)
                    {
                        historyList.Add(_mapper.Map<ReservationModel>((Reservation)temp));
                    }
                }
            }

            return await Task.FromResult(historyList);
        }
    }
}
