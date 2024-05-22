using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize
            Queue<int> guests = new Queue<int>();
            Stack<int> food = new Stack<int>();
            int wastedFoodGrams = 0;

            //Add guests
            int[] guestCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (var guest in guestCapacity)
            {
                guests.Enqueue(guest);
            }
            
            //Add food
            int[] foodPlates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (var plate in foodPlates)
            {
                food.Push(plate);
            }

            //Feed guests
            int currentGuestHunger = guests.Peek();
            while (true)
            {
                int currentFood = food.Peek();
                if (currentFood >= currentGuestHunger)
                {
                    currentFood -= currentGuestHunger;
                    wastedFoodGrams += currentFood;
                    guests.Dequeue();
                    if (guests.Count > 0)
                    {           
                        currentGuestHunger = guests.Peek();
                    }
                    food.Pop();
                }
                else
                {
                    currentGuestHunger -= currentFood;
                    food.Pop();
                }
                if (guests.Count == 0 || food.Count == 0)
                {
                    break;
                }
            }

            if (guests.Count > 0)
            {
                Console.Write("Guests:");
                foreach (var guest in guests)
                {
                    Console.Write($" {guest} ".TrimEnd());
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted grams of food: {wastedFoodGrams}");
            }
            else
            {
                Console.Write("Plates:");
                foreach (var plate in food)
                {
                    Console.Write($" {plate} ".TrimEnd());
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted grams of food: {wastedFoodGrams}");
            }
        }
    }
}
