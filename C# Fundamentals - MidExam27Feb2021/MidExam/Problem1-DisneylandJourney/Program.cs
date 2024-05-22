using System;

namespace Problem1_DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int monthsToSave = int.Parse(Console.ReadLine());

            double savedMoney = 0;
            for (int i = 1; i <= monthsToSave; i++)
            {
                if (i % 2 == 1 &&
                    i != 1)
                {
                    savedMoney = savedMoney * 0.84;
                }
                if (i % 4 == 0)
                {
                    savedMoney += savedMoney * 0.25;
                }
                savedMoney += journeyCost * 0.25;
            }

            if (savedMoney >= journeyCost)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {savedMoney-journeyCost:F2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {journeyCost-savedMoney:F2}lv. more.");
            }
        }
    }
}
