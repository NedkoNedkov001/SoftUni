using System;

namespace PadwanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double totalLightsaberPrice = Math.Ceiling(students * 1.10) * lightsaberPrice;
            double totalRobePrice = students * robePrice;
            double totalBeltPrice = (students * beltPrice) - ((students / 6) * beltPrice);

            double totalCost = totalBeltPrice + totalRobePrice + totalLightsaberPrice;

            if (money >= totalCost)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalCost-money:F2}lv more.");
            }
        }
    }
}
