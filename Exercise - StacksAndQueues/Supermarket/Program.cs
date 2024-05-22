using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }
                else if (input.ToLower() == "paid")
                { 
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(input);
                }
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
