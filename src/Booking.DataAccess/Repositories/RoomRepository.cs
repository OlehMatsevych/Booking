using Booking.Core.Entities;
using Booking.DataAccess.Extensions;
using Booking.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Booking.DataAccess.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly BookingContext _context;
        public RoomRepository(BookingContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Room> GetFreeRoomsByLocation(string city)
        {
            var query = from r in _context.Rooms
                        where r.IsFree == true
                        &&
                        (from a in _context.Apartments
                         where
                             (from l in _context.Locations
                              where l.City == city
                              select l.Id
                             ).Contains(a.LocationId)
                         select a.Id
                        ).Contains(r.Apartment.Id)
                        &&
                        !(from res in _context.Reservations
                          where res.StartDate == DateTime.Now
                          select res.Id
                          ).Contains(r.Id)

                        select r;

            //var sql = query.ToSql();
            return query.ToList();
        }
        public object GetFreeRoomsAndGuests(string country)
        {
            var query = from r in _context.Rooms
                        join guest in _context.Guests
                             on (from a in _context.Apartments
                                 where a.Id == r.Apartment.Id
                                 select a.Guest.Id).First()

                             equals guest.Id

                        into g
                        from gu in g.DefaultIfEmpty()

                        where
                            (from rd in _context.RoomsDetails
                             where rd.RoomsAmount == 2
                             select rd.Id
                            ).Contains(r.RoomDetails.Id)
                            &&
                            (from a in _context.Apartments
                             where
                                (from l in _context.Locations
                                 where l.Country != country
                                 select l.Id
                                ).Contains(a.LocationId)

                             select a.Id

                            ).Contains(r.Apartment.Id)

                        select new 
                        { 
                            r.Id, 
                            r.IsFree, 
                            Guests = gu 
                        };

            return query.FirstOrDefault();
        }

    }
}
