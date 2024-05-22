using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader str = new StreamReader("text.txt");

            int count = 0;
            while (!str.EndOfStream)
            {
                string line = str.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (count % 2 == 0)
                {
                    line = ReplacePunctuation(line, '@');
                    string[] words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    words = words.Reverse()
                    .ToArray();
                    Console.WriteLine(string.Join(" ", words));
                }
                count++;
            }
        }

        static string ReplacePunctuation(string line, char replacingChar)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];
                if (char.IsPunctuation(currentSymbol))
                {
                    sb.Append(replacingChar);
                }
                else
                {
                    sb.Append(currentSymbol);
                }
            }
            return sb
                .ToString()
                .TrimEnd();
        }
    }
}
