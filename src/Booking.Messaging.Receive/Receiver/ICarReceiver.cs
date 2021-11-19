using System.Collections.Generic;

namespace Booking.Messaging.Receive.Receiver
{
    public interface ICarReceiver
    {
        IEnumerable<string> ReceiveCar();
    }
}
