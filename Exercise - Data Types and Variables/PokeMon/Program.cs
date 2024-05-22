using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine());
            int currentPower = powerN;
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionY = int.Parse(Console.ReadLine());

            int pokedTargets = 0;

            while (currentPower >= distanceM)
            {
                pokedTargets++;
                currentPower -= distanceM;
                if (currentPower == powerN / 2 && exhaustionY > 0)
                {
                    currentPower /= exhaustionY;
                }
            }
            Console.WriteLine(currentPower);
            Console.WriteLine(pokedTargets);
        }
    }
}
