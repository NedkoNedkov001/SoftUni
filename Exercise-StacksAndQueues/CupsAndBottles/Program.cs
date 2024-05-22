using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int[] cupsArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> cups = new Queue<int>(cupsArr);

            int[] bottlesArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bottles = new Stack<int>(bottlesArr);

            //Calculations
            int wastedWater = 0;

            int currentBottle = bottles.Peek();
            int currentCup = cups.Peek();
            while (bottles.Count > 0 && cups.Count > 0)
            {
                currentBottle -= currentCup;


                if (currentBottle >= 0)
                {
                    cups.Dequeue();
                    bottles.Pop();
                    wastedWater += currentBottle;
                    if (bottles.Count() == 0 || cups.Count() == 0)
                    {
                        break;
                    }
                    currentBottle = bottles.Peek();
                    currentCup = cups.Peek();

                }
                else if (currentBottle <= 0)
                {
                    currentCup -= bottles.Pop();
                    if (bottles.Count > 0)
                    {
                        currentBottle = bottles.Peek();
                    }
                    
                }
            }

            //Output
            if (cups.Count == 0)
            {
                string remainingBottles = string.Join(" ", bottles);
                Console.WriteLine($"Bottles: {remainingBottles}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (bottles.Count == 0)
            {
                string remainingCups = string.Join(" ", cups);
                Console.WriteLine($"Cups: {remainingCups}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }

            
        }
    }
}
