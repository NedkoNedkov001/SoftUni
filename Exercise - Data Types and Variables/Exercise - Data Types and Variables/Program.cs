using System;

namespace Exercise___Data_Types_and_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            long thirdNumber = long.Parse(Console.ReadLine());
            long fourthNumber = long.Parse(Console.ReadLine());

            long result = 0;

            result = (firstNumber + secondNumber) / thirdNumber * fourthNumber;
            Console.WriteLine(result);
        }
    }
}
