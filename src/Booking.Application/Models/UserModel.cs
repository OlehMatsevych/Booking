using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Models
{
    public class UserModel: BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
