using System;

namespace Booking.Application.Exceptions
{
    public class EmptyObjectException: Exception
    {
        public EmptyObjectException(string message):base(message)
        { }
    }
}
