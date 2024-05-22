using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bullets = new Stack<int>(bulletsArr);
            int[] locksArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> locks = new Queue<int>(locksArr);
            int value = int.Parse(Console.ReadLine());
            int bulletsCost = 0;

            int bulletsInBarrel = barrelSize;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (--bulletsInBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsInBarrel = barrelSize;
                }
                bulletsCost += bulletPrice;
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - bulletsCost}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
