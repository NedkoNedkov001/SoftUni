using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadsets = 0;
            int trashedMice = 0;
            int trashedKeyboards = 0;
            int trashedDisplays = 0;

            //2, 3, 6, 12;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 12 == 0)
                {
                    trashedDisplays++;
                    trashedKeyboards++;
                    trashedMice++;
                    trashedHeadsets++;
                }
                else if (i % 6 == 0)
                {
                    trashedKeyboards++;
                    trashedMice++;
                    trashedHeadsets++;
                }
                else if (i % 3 == 0)
                {
                    trashedMice++;
                }
                else if (i % 2 == 0)
                {
                    trashedHeadsets++;
                }
            }

            double totalCost = (trashedHeadsets * headsetPrice) + (trashedMice * mousePrice) + (trashedKeyboards * keyboardPrice) + (trashedDisplays * displayPrice);
            Console.WriteLine($"Rage expenses: {totalCost:F2} lv.");
        }
    }
}
