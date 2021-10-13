using System;

namespace Booking.Core.Common
{
    public interface IChangeEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}
