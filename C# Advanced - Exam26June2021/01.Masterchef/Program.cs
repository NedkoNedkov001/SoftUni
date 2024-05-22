using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingrediens = new Queue<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .Where(x => x != 0));

            Stack<int> freshnes = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            



            int sauce = 150;
            int greenSalad = 250;
            int cake = 300;
            int lobster = 400;

            int sauceCount = 0;
            int saladCount = 0;
            int cakeCount = 0;
            int lobsterCount = 0;

            while (ingrediens.Count > 0 && freshnes.Count > 0)
            {
                int sum = ingrediens.Peek() * freshnes.Peek();

                if (sum == sauce || sum == greenSalad || sum == cake || sum == lobster)
                {
                    if (sum == sauce)
                    {
                        sauceCount++;
                    }
                    else if (sum == greenSalad)
                    {
                        saladCount++;
                    }
                    else if (sum == cake)
                    {
                        cakeCount++;
                    }
                    else
                    {
                        lobsterCount++;
                    }

                    ingrediens.Dequeue();
                    freshnes.Pop();
                }
                else
                {
                    freshnes.Pop();
                    int newIngredient = ingrediens.Dequeue() + 5;
                    ingrediens.Enqueue(newIngredient);
                }
            }

            if (sauceCount >= 1 && saladCount >= 1 && cakeCount >= 1 && lobsterCount >= 1)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingrediens.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingrediens.Sum()}");
            }

            if (cakeCount > 0)
            {
                Console.WriteLine($" # Chocolate cake --> {cakeCount}");
            }

            if (sauceCount > 0)
            {
                Console.WriteLine($" # Dipping sauce --> {sauceCount}");
            }

            if (saladCount > 0)
            {
                Console.WriteLine($" # Green salad --> {saladCount}");
            }

            if (lobsterCount > 0)
            {
                Console.WriteLine($" # Lobster --> {lobsterCount}");
            }
        }
    }
}