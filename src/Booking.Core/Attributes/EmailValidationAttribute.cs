using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.Core.Attributes
{
    public class EmailValidationAttribute: ValidationAttribute
    {
        public const string ExceptionMessage = "Not valid email";

        public override bool IsValid(object Email)
        {
            string email = (string)Email;
            if (email.Trim().EndsWith("."))
            {
                throw new Exception(ExceptionMessage);
            }
            if (!email.Contains('@'))
            {
                throw new Exception(ExceptionMessage);
            }
            return true;
        }
    }
}
