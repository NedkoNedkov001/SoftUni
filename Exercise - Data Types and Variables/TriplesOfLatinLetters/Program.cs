using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 'a'; i < 'a'+number; i++)
            {
                for (int j = 'a'; j < 'a'+number; j++)
                {
                    for (int k = 'a'; k < 'a'+number; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
