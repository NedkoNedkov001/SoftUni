using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3_Cupid
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int cupidCurrIdx = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Love!")
                {
                    break;
                }

                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                cupidCurrIdx += int.Parse(command[1]);
                if (cupidCurrIdx >= neighborhood.Count)
                {
                    cupidCurrIdx = 0;
                }

                if (neighborhood[cupidCurrIdx] > 0)
                {
                    neighborhood[cupidCurrIdx] -= 2;
                    if (neighborhood[cupidCurrIdx] == 0)
                    {
                        Console.WriteLine($"Place {cupidCurrIdx} has Valentine's day.");
                    }
                }
                else
                {
                    Console.WriteLine($"Place {cupidCurrIdx} already had Valentine's day.");
                }
            }
            Console.WriteLine($"Cupid's last position was {cupidCurrIdx}.");

            bool missionSuccessfull = true;
            int failedPlaces = 0;
            for (int i = 0; i < neighborhood.Count; i++)
            {
                if (neighborhood[i] > 0)
                {
                    missionSuccessfull = false;
                    failedPlaces++;
                }
            }

            if (missionSuccessfull)
            {
                Console.WriteLine("Mission was successful.");
            }
            else 
            {
                Console.WriteLine($"Cupid has failed {failedPlaces} places.");
            }
        }

        private static void GiveHearts(List<int> neighborhood, int cupidCurrIdx, int jumpIdx)
        {
            
        }
    }
}
