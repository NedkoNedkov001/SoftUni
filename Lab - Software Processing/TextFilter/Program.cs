﻿using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string input = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                input = input.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
            }
            Console.WriteLine(input);
        }
    }
}
