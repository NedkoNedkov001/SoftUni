using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] characters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string lineOne = characters[0];
            string lineTwo = characters[1];

            int maxIndex = (Math.Min(lineOne.Length, lineTwo.Length));
            int sum = 0;

            sum = FindSum(lineOne, lineTwo, maxIndex, sum);
            Console.WriteLine(sum);
        }

        private static int FindSum(string lineOne, string lineTwo, int maxIndex, int sum)
        {
            for (int i = 0; i < maxIndex; i++)
            {
                sum += lineOne[i] * lineTwo[i];
            }

            if (lineOne.Length > lineTwo.Length)
            {
                for (int i = maxIndex; i < lineOne.Length; i++)
                {
                    sum += lineOne[i];
                }
            }
            else if (lineOne.Length < lineTwo.Length)
            {
                for (int i = maxIndex; i < lineTwo.Length; i++)
                {
                    sum += lineTwo[i];
                }
            }
            return sum;
        }
    }
}
