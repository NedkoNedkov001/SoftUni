using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Calculations(operation, num1, num2);
        }

        static void Calculations(string operation, int num1, int num2)
        {
            string result = null;
            if (operation == "add")
            {
                result = $"{num1 + num2}";
            }
            else if (operation == "multiply")
            {
                result = $"{num1 * num2}";
            }
            else if (operation == "subtract")
            {
                result = $"{num1 - num2}";
            }
            else if (operation == "divide")
            {
                result = $"{num1 / num2}";
            }
            Console.WriteLine(result);
        }
    }
}
