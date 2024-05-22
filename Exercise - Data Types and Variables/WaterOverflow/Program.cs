using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int tankFills = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            int litresInTank = 0;

            for (int i = 0; i < tankFills; i++)
            {
                int currentFill = int.Parse(Console.ReadLine());
                if (currentFill <= tankCapacity)
                {
                    tankCapacity -= currentFill;
                    litresInTank += currentFill;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(litresInTank);
        }
    }
}
