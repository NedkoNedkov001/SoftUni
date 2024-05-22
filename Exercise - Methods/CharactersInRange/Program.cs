using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char charOne = char.Parse(Console.ReadLine());
            char charTwo = char.Parse(Console.ReadLine());

            GetCharactersInRange(charOne, charTwo);
        }

        private static void GetCharactersInRange(char charOne, char charTwo)
        {
            int start = 0;
            int end = 0;

            if ((int)charOne > (int)charTwo)
            {
                start = (int)charTwo;
                end = (int)charOne;
            }
            else
            {
                start = (int)charOne;
                end = (int)charTwo;
            }

            char currentChar = ' ';
            for (int i = start + 1; i < end; i++)
            {
                currentChar = (char)i;
                Console.Write($"{currentChar} ");
            }
        }
    }
}
