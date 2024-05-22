using System;
using System.Linq;
namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                bool isPalindrome = CheckIfPalindrome(input);
                Console.WriteLine(isPalindrome);
            }
        }

        private static bool CheckIfPalindrome(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string inputReversed = String.Concat(charArray);

            if (input == inputReversed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
