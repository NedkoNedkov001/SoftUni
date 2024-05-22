using System;

namespace TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if (day == "Weekday" && age >= 0 && age <= 18)
            {
                ticketPrice = 12;
            }
            else if (day == "Weekday" && age > 18 && age <= 64)
            {
                ticketPrice = 18;
            }
            else if (day == "Weekday" && age > 64 && age <= 122)
            {
                ticketPrice = 12;
            }
            else if (day == "Weekend" && age >= 0 && age <= 18)
            {
                ticketPrice = 15;
            }
            else if (day == "Weekend" && age > 18 && age <= 64)
            {
                ticketPrice = 20;
            }
            else if (day == "Weekend" && age > 64 && age <= 122)
            {
                ticketPrice = 15;
            }
            else if (day == "Holiday" && age >= 0 && age <= 18)
            {
                ticketPrice = 5;
            }
            else if (day == "Holiday" && age > 18 && age <= 64)
            {
                ticketPrice = 12;
            }
            else if (day == "Holiday" && age > 64 && age <= 122)
            {
                ticketPrice = 10;
            }

            if (ticketPrice > 0)
            {
                Console.WriteLine($"{ticketPrice}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
            
        }
    }
}
