using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registeredPeople = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string name = input[1];

                if (command == "register")
                {
                    string number = input[2];

                    if (registeredPeople.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registeredPeople[name]}");
                    }
                    else
                    {
                        registeredPeople.Add(name, number);
                        Console.WriteLine($"{name} registered {number} successfully");
                    }
                }
                else
                {
                    if (registeredPeople.ContainsKey(name))
                    {
                        registeredPeople.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }

            foreach (var registered in registeredPeople)
            {
                Console.WriteLine($"{registered.Key} => {registered.Value}");
            }
        }
    }
}
