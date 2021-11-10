using AutoMapper;
using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Booking.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoomModel>> GetFreeRoomsByApartmentId(Guid apartmentId)
        {
            var entities = _repository.GetWhere(x => x.Apartment.Id == apartmentId);
            if(entities == null)
            {
                throw new Exception();
            }
            return await Task.FromResult(_mapper.Map<IEnumerable<RoomModel>>(entities));

        }

        public async Task<IEnumerable<RoomModel>> GetRooms()
        {
            var entities = await _repository.GetAllAsync();
            if (entities == null)
            {
                throw new Exception();
            }
            return  _mapper.Map<IEnumerable<RoomModel>>(entities);
        }
    }
}
