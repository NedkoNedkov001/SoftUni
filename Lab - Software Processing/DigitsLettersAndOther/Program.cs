using System;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (var character in input)
            {
                if (char.IsDigit(character))
                {
                    Console.Write(character);
                }
            }
            Console.WriteLine();
            foreach (var character in input)
            {
                if (char.IsLetter(character))
                {
                    Console.Write(character);
                }
            }
            Console.WriteLine();
            foreach (var character in input)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    Console.Write(character);
                }
            }
        }
    }
}
