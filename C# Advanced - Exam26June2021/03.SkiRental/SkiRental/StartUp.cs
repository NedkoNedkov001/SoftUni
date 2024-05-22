using System;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomSize = Console.ReadLine();
            string feedback = Console.ReadLine();
            var roomForOne = 18.00;
            var appartment = 25.00;
            var presidentalAppartment = 35.00;

            if (days < 10)
            {
                if (roomSize == "room for one person")
                {
                    roomForOne = (days - 1) * 18;
                }
                else if (roomSize == "apartment")
                {
                    appartment = (days - 1) * 25;
                    appartment = appartment - (appartment * 0.30);
                }
                else if (roomSize == "president apartment")
                {
                    presidentalAppartment = (days - 1) * 35;
                    presidentalAppartment = presidentalAppartment - (presidentalAppartment * 0.10);
                }
            }
            else if (days >= 10 && days <= 15)
            {
                if (roomSize == "room for one person")
                {
                    roomForOne = (days - 1) * 18;
                }
                else if (roomSize == "apartment")
                {
                    appartment = (days - 1) * 25;
                    appartment = appartment - (appartment * 0.35);
                }
                else if (roomSize == "president apartment")
                {
                    presidentalAppartment = (days - 1) * 35;
                    presidentalAppartment = presidentalAppartment - (presidentalAppartment * 0.15);
                }
            }
            else if (days > 15)
            {
                if (roomSize == "room for one person")
                {
                    roomForOne = (days - 1) * 18;
                }
                else if (roomSize == "apartment")
                {
                    appartment = (days - 1) * 25;
                    appartment = appartment - (appartment * 0.50);
                }
                else if (roomSize == "president apartment")
                {
                    presidentalAppartment = (days - 1) * 35;
                    presidentalAppartment = presidentalAppartment - (presidentalAppartment * 0.20);
                }
            }
            if (feedback == "positive")
            {
                if (roomSize == "room for one person")
                {
                    Console.WriteLine($"{(roomForOne * 0.25) + roomForOne:F2}");
                }
                else if (roomSize == "apartment")
                {
                    Console.WriteLine($"{(appartment * 0.25) + appartment:F2}");
                }
                else if (roomSize == "president apartment")
                {
                    Console.WriteLine($"{(presidentalAppartment * 0.25) + presidentalAppartment:F2}");
                }
            }
            else
            {
                if (roomSize == " room for one person")
                {
                    Console.WriteLine($"{roomForOne - (roomForOne * 0.10):F2}");
                }
                else if (roomSize == "apartment")
                {
                    Console.WriteLine($"{appartment - (appartment * 0.10):F2}");
                }
                else if (roomSize == "president apartment")
                {
                    Console.WriteLine($"{presidentalAppartment - (presidentalAppartment * 0.10):F2}");
                }
            }
        }
    }
}
