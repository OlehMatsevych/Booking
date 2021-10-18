using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
    }
}
