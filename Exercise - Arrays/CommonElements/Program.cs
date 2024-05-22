using System;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstLineWord = "";

            string[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string secondLineWord = "";

            for (int i = 0; i < secondLine.Length; i++)
            {
                secondLineWord = secondLine[i];

                for (int j = 0; j < firstLine.Length; j++)
                {
                    firstLineWord = firstLine[j];
                    if (secondLineWord == firstLineWord)
                    {
                        Console.Write($"{secondLineWord} ");
                    }
                }
            }
        }
    }
}
