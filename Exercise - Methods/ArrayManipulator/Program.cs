using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "end")
                {
                    break;
                }
                else if (command[0] == "exchange")
                {
                    intArray = ArraySplit(intArray, command[1]);
                }
                else if (command[0] == "max")
                {
                    Console.WriteLine($"{ArrayMaxIndex(intArray, command[1])}");
                }
                else if (command[0] == "min")
                {
                    Console.WriteLine($"{ArrayMinIndex(intArray, command[1])}");
                }
                else if (command[0] == "first")
                {
                    Console.WriteLine($"{FirstElements(intArray, command[1], command[2])}");
                }
                else if (command[0] == "last")
                {
                    Console.WriteLine($"{LastElements(intArray, command[1], command[2])}");

                }
            }


            string finalArray = "";

            for (int i = 0; i < intArray.Length; i++)
            {
                finalArray += $"{intArray[i]}, ";
            }

            finalArray = finalArray.Trim(',',' ');

            Console.WriteLine($"[{finalArray}]");
        }
        private static string LastElements(int[] intArray, string parameterOne, string parameterTwo)
        {
            int count = int.Parse(parameterOne);
            string result = "";

            if (count > intArray.Length)
            {
                result = "Invalid count";
                return result;
            }
            if (parameterTwo == "odd")
            {
                for (int i = intArray.Length - 1; i >= 0; i--)
                {
                    if (intArray[i] % 2 == 1)
                    {
                        result += $"{intArray[i]} ,";
                        count--;
                        if (count == 0)
                        {
                            break;
                        }
                    }
                }
            }
            else if (parameterTwo == "even")
            {
                for (int i = intArray.Length - 1; i >= 0; i--)
                {
                    if (intArray[i] % 2 == 0)
                    {
                        result += $"{intArray[i]} ,";
                        count--;
                        if (count == 0)
                        {
                            break;
                        }
                    }
                }
            }

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            result = String.Concat(charArray);

            result = $"[{result.Trim(',', ' ')}]";
            return result;

        }
        private static string FirstElements(int[] intArray, string parameterOne, string parameterTwo)
        {
            int count = int.Parse(parameterOne);
            string result = "";

            if (count > intArray.Length)
            {
                result = "Invalid count";
                return result;
            } 

                if (parameterTwo == "odd")
                {
                for (int i = 0; i < intArray.Length; i++)
                    {
                        if (intArray[i] % 2 == 1)
                        {
                            result += $"{intArray[i]}, ";
                            count--;
                            if (count == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (parameterTwo == "even")
                {
                    for (int i = 0; i < intArray.Length; i++)
                    {
                        if (intArray[i] % 2 == 0)
                        {
                            result += $"{intArray[i]}, ";
                            count--;
                            if (count == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                
            
            result = $"[{result.Trim(',', ' ')}]";
            return result;

        }
        private static string ArrayMinIndex(int[] intArray, string parameter)
        {
            int maxNumber = int.MaxValue;
            string maxNumberIndex = "";
            if (parameter == "odd")
            {
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] <= maxNumber &&
                        intArray[i] % 2 == 1)
                    {
                        maxNumber = intArray[i];
                        maxNumberIndex = $"{i}";
                    }
                }
            }
            else if (parameter == "even")
            {
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] <= maxNumber &&
                        intArray[i] % 2 == 0)
                    {
                        maxNumber = intArray[i];
                        maxNumberIndex = $"{i}";
                    }
                }
            }
            if (maxNumberIndex == "")
            {
                maxNumberIndex = "No matches";
            }
            return maxNumberIndex;
        }
        private static string ArrayMaxIndex(int[] intArray, string parameter)
        {
            int maxNumber = int.MinValue;
            string maxNumberIndex = "";
            if (parameter == "odd")
            {
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] >= maxNumber &&
                        intArray[i] % 2 == 1)
                    {
                        maxNumber = intArray[i];
                        maxNumberIndex = $"{i}";
                    }
                }
            }
            else if (parameter == "even")
            {
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] >= maxNumber &&
                        intArray[i] % 2 == 0)
                    {
                        maxNumber = intArray[i];
                        maxNumberIndex = $"{i}";
                    }
                }
            }
            if (maxNumberIndex == "")
            {
                maxNumberIndex = "No matches";
            }
            return maxNumberIndex;
        }
        private static int[] ArraySplit(int[] intArray, string parameter)
        {
            if (int.Parse(parameter) >= intArray.Length)
            {
                Console.WriteLine("Invalid index");
                return intArray;
            }
            for (int i = 0; i <= int.Parse(parameter); i++)
            {
                int firstNumber = intArray[0];
                for (int j = 1; j < intArray.Length; j++)
                {
                    intArray[j - 1] = intArray[j];
                }
                intArray[intArray.Length - 1] = firstNumber;
            }
            return intArray;
        }
    }
}
