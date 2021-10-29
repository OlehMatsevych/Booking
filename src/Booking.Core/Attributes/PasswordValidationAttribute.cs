using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Booking.Core.Attributes
{
    public class PasswordValidationAttribute: ValidationAttribute
    {
        public const string ExceptionMessage = "Not valid password";
        public override bool IsValid(object value)
        {
            string password = (string)value;
            if (password == null || !password.Any(char.IsDigit) || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                throw new Exception(ExceptionMessage);
            }
            return true;
        }
    }
}
