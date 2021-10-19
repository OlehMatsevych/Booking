using System;

namespace Booking.Application.Exceptions
{
    public class ArgumentRequestException : Exception
    {
        public ArgumentRequestException(string message) : base(message)
        { }
    }
}
