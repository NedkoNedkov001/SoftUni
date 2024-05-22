using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegsNumber = int.Parse(Console.ReadLine());
            string biggestKeg = "";
            double biggestVolume = 0;

            for (int i = 0; i < kegsNumber; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;
                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestKeg = kegModel;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
