using System;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int longestSequence = 0;
            string longestSequenceElement = "";

            for (int i = 0; i < array.Length; i++)
            {
                int currentSequence = 1;
                string currentElement = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] == currentElement)
                    {
                        currentSequence++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    longestSequenceElement = currentElement;
                }
            }
            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write($"{longestSequenceElement} ");
            }
        }
    }
}
