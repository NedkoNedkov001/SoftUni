using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string Invalid_number_exception_message = "Invalid number!";
        public InvalidPhoneNumberException() 
            : base(Invalid_number_exception_message)
        {

        }
    }
}
