using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int totalCarsPassed = 0;
            Queue<string> cars = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }
                else if (input.ToLower() == "green")
                {
                    int currentGreenLight = greenLight;
                    int currendFreeWindow = freeWindow;
                    while (currentGreenLight > 0 && cars.Count != 0)
                    {
                        string currentCar = cars.Dequeue();
                        currentGreenLight -= currentCar.Length;

                        if (currentGreenLight > 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            currendFreeWindow += currentGreenLight;

                            if (currendFreeWindow < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[currentCar.Length + currendFreeWindow]}.");
                                return;
                            }
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
