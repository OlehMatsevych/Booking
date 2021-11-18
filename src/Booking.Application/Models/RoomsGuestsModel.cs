using Booking.Core.Entities;
using System;
using System.Collections.Generic;

namespace Booking.Application.Models
{
    public class RoomsGuestsModel
    {
        public Guid Id { get; set; }
        public bool IsFree { get; set; }
        public Guest Guests { get; set; } 
    }
}
