using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");
            string[] newLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                int lettersCount = CountLetters(currentLine);
                int punctuationCount = CountPunctuation(currentLine);

                newLines[i] = $"Line {i + 1}: {currentLine} ({lettersCount})({punctuationCount})";
                Console.WriteLine(newLines[i]);
            }
            File.WriteAllLines("../../../output.txt", newLines);

        }

        private static int CountPunctuation(string currentLine)
        {
            int count = 0;
            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentChar = currentLine[i];
                if (char.IsPunctuation(currentChar))
                {
                    count++;
                }
            }
            return count;
        }

        private static int CountLetters(string currentLine)
        {
            int count = 0;
            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentChar = currentLine[i];
                if (char.IsLetter(currentChar))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
