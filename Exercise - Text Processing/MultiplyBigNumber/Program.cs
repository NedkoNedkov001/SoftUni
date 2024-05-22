using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            //1234
            //4

            //4936
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            List<string> result = new List<string>();

            int remainder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = ((number[i] - '0') * multiplier + remainder);

                remainder = digit / 10;
                digit %= 10;

                result.Add(digit.ToString());
            }
            if (remainder > 0)
            {
                result.Add(remainder.ToString());
            }

            if (multiplier == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                result.Reverse();
                Console.WriteLine(string.Join("", result));

            }
        }
    }
}
