using Booking.Core.Entities;
using System.Collections.Generic;

namespace Booking.DataAccess.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        IEnumerable<Room> GetFreeRoomsByLocation(string city);
        object GetFreeRoomsAndGuests(string country);
    }
}
