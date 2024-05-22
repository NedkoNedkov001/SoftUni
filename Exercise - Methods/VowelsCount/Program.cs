using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelsCount = GetVowelsCount(input);
            Console.WriteLine(vowelsCount);
        }

        static int GetVowelsCount(string input)
        {
            int vowelsCount = 0;
            input = input.ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' ||
                    input[i] == 'o' ||
                    input[i] == 'e' ||
                    input[i] == 'i' ||
                    input[i] == 'u')
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
