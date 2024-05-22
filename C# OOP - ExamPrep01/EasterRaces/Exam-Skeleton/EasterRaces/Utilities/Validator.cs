using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Utilities
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullEmptyOrLessThan(string str, int minLenght, string message)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < minLenght)
            {
                throw new ArgumentException(message);
            }
        }
    }


}
