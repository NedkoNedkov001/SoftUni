using System;
using System.Text.RegularExpressions;

namespace Problem02
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();
                Regex pattern = new Regex(@"^(.+)\>(?<Numbers>\d{3})\|(?<Lower>[a-z]{3})\|(?<Upper>[A-Z]{3})\|(?<Symbols>[^\<\>]{3})\<\1$");
                Match passMatch = pattern.Match(password);

                if (passMatch.Success)
                {
                    string numbers = passMatch.Groups["Numbers"].Value;
                    string lower = passMatch.Groups["Lower"].Value;
                    string upper = passMatch.Groups["Upper"].Value;
                    string symbols = passMatch.Groups["Symbols"].Value;

                    string encryptedPassword = numbers + lower + upper + symbols;
                    Console.WriteLine($"Password: {encryptedPassword}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
