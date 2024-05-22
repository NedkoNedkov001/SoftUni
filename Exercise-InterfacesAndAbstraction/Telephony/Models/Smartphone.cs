using System.Linq;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                return $"Calling... {phoneNumber}";
            }    
            throw new InvalidPhoneNumberException();
        }
    }
}
