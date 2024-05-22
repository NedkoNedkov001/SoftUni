using System;

namespace Lab___Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int dayOfWeek = int.Parse(Console.ReadLine());

            if (dayOfWeek > 0 && dayOfWeek < 8)
            {
                Console.WriteLine($"{daysOfWeek[dayOfWeek - 1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
