using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            string peopleType = Console.ReadLine();
            string weekday = Console.ReadLine();

            double personPrice = 0;
            double totalPrice = 0;
            if (weekday == "Friday" && peopleType == "Students")
            {
                personPrice = 8.45;
            }
            else if (weekday == "Friday" && peopleType == "Business")
            {
                personPrice = 10.90;
            }
            else if (weekday == "Friday" && peopleType == "Regular")
            {
                personPrice = 15;
            }
            else if (weekday == "Saturday" && peopleType == "Students")
            {
                personPrice = 9.80;
            }
            else if (weekday == "Saturday" && peopleType == "Business")
            {
                personPrice = 15.60;
            }
            else if (weekday == "Saturday" && peopleType == "Regular")
            {
                personPrice = 20;
            }
            else if (weekday == "Sunday" && peopleType == "Students")
            {
                personPrice = 10.46;
            }
            else if (weekday == "Sunday" && peopleType == "Business")
            {
                personPrice = 16;
            }
            else if (weekday == "Sunday" && peopleType == "Regular")
            {
                personPrice = 22.50;
            }

            totalPrice = personPrice * peopleNumber;

            if (peopleType == "Students" && peopleNumber >= 30)
            {
                totalPrice = totalPrice * 0.85;
            }
            else if (peopleType == "Business" && peopleNumber >= 100)
            {
                totalPrice = totalPrice - 10 * personPrice;
            }
            else if (peopleType == "Regular" && peopleNumber >= 10 && peopleNumber <= 20)
            {
                totalPrice = totalPrice * 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");

        }
    }
}
