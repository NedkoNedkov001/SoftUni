using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            GetMax(type);


        }
        static void GetMax(string type)
        {
            switch (type)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    if (num1 > num2)
                    {
                        Console.WriteLine(num1);
                    }
                    else
                    {
                        Console.WriteLine(num2);
                    }
                    break;
                case "char":
                    char char1 = char.Parse(Console.ReadLine());
                    char char2 = char.Parse(Console.ReadLine());
                    if (char1 > char2)
                    {
                        Console.WriteLine(char1);
                    }
                    else
                    {
                        Console.WriteLine(char2);
                    }
                    break;
                case "string":
                    string string1 = Console.ReadLine();
                    string string2 = Console.ReadLine();
                    if (string1.CompareTo(string2) == -1)
                    {
                        Console.WriteLine(string2);
                    }
                    else
                    {
                        Console.WriteLine(string1);
                    }
                    break;
            }

        }
    }
}
