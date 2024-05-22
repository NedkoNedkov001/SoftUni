using System;
using System.Text;
using System.Linq;

namespace FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {

            //StringBuilder str = new StringBuilder();
            //str.Append(Console.ReadLine());

            string str = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }

                string[] command = input
                    .Split();

                if (command[0] == "Replace")
                {
                    str = ReplaceChar(str, command[1], command[2]);
                }

                else if (command[0] == "Cut")
                {
                    str = CutString(str, command[1], command[2]);
                }
                else if (command[0] == "Make")
                {
                    str = MakeCharacters (str, command[1]);
                }
                else if (command[0] == "Check")
                {
                    CheckString(str, command[1]);
                }
                else if (command[0] == "Sum")
                {
                    SumIndices(str, command[1], command[2]);
                }
            }
        }

        private static void SumIndices(string str, string startIndex, string endIndex)
        {
            int startIdx = int.Parse(startIndex);
            int endIdx = int.Parse(endIndex);

            if (startIdx < 0 || endIdx >= str.Length)
            {
                Console.WriteLine("Invalid indices!");
            }
            else
            {
                int sum = 0;
                for (int i = startIdx; i <= endIdx; i++)
                {
                    sum += (int)str[i];
                }
                Console.WriteLine(sum);
            }
        }

        private static string MakeCharacters(string str, string v)
        {
            if (v == "Upper")
            {
                str = str.ToUpper();
            }
            else if (v == "Lower")
            {
                str = str.ToLower();
            }
            Console.WriteLine(str);

            return str;
        }

        private static string CutString(string str, string startIndex, string endIndex)
        {
            int startIdx = int.Parse(startIndex);
            int endIdx = int.Parse(endIndex);

            if (startIdx < 0 || endIdx >= str.Length)
            {
                Console.WriteLine("Invalid indices!");
            }
            else
            {
                str = str.Remove(startIdx, (endIdx - startIdx)+1);
                Console.WriteLine(str);
            }
            return str;
        }

        private static void CheckString(string str, string v)
        {
            if (str.Contains(v))
            {
                Console.WriteLine($"Message contains {v}");
            }
            else
            {
                Console.WriteLine($"Message doesn't contain {v}");
            }
            
        }

        private static string ReplaceChar(string str, string character, string replacement)
        {
            str = str.Replace(character, replacement);
            Console.WriteLine(str);
            return str;
        }
    }
}
