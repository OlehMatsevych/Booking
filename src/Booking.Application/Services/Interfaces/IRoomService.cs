using Booking.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomModel>> GetRooms();
        Task<IEnumerable<RoomModel>> GetFreeRoomsByApartmentId(Guid apartmentId);
    }
}
