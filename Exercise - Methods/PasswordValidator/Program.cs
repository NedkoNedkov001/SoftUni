using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValid = true;

            isValid = CheckPasswordLength(password, isValid);
            isValid = CheckForSpecialSymbols(password, isValid);
            isValid = CheckDigitsCount(password, isValid);

            if (isValid == true)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool CheckDigitsCount(string password, bool isValid)
        {
            int digitsCount = 0;

            foreach (var symbol in password)
            {   
                if (char.IsDigit(symbol))
                {
                    digitsCount++;
                }
            }

            if (digitsCount < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            return isValid;
        }

        private static bool CheckForSpecialSymbols(string password, bool isValid)
        {
            bool hasSpecialChar = false;
            foreach (var symbol in password)
            {
                if (char.IsLetterOrDigit(symbol))
                {
                    isValid = true;
                }
                else
                {
                    hasSpecialChar = true;
                    isValid = false;
                }
            }
            if (hasSpecialChar)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            return isValid;
        }

        private static bool CheckPasswordLength(string password, bool isValid)
        {
            if (password.Length < 6 || 
                password.Length > 10)
            {
                isValid = false;
                Console.WriteLine($"Password must be between 6 and 10 characters");
            }

            return isValid;
        }
    }
}
