using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int carsPassed = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }
                else if (input.ToLower() == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            carsPassed++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
