using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToRepeat = Console.ReadLine();
            int timesToRepeat = int.Parse(Console.ReadLine());

            string result = RepeatString(stringToRepeat, timesToRepeat);

            Console.WriteLine(result);
        }

        static string RepeatString(string stringToRepeat, int timesToRepeat)
        {
            string result = "";

            for (int i = 0; i < timesToRepeat; i++)
            {
                result += stringToRepeat;
            }
            return result;
        }
    }
}
