using AutoMapper;
using Booking.Application.Constants;
using Booking.Application.Exceptions;
using Booking.Application.Helpers;
using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

using ApartmentEntity = Booking.Core.Entities.Apartment;

namespace Booking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper, IReservationRepository reservationRepository)
        {
            _repository = repository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }
        public async Task<OperationStatus> AddReservation(ReservationModel reservation)
        {
            var entity = _mapper.Map<Reservation>(reservation);
            if(entity == null)
            {
                throw new EmptyObjectException(ReservationErrorMessages.ReservationNotFoundException);
            }
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
    }
}
