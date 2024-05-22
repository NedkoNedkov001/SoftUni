using System;
using System.Linq;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                return $"Dialing... {phoneNumber}";
            }
            throw new InvalidPhoneNumberException();
        }
    }
}
