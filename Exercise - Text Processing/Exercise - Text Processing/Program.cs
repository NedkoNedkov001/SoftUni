using System;

namespace Exercise___Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);


            foreach (var username in usernames)
            {
                UserValidation(username);
            }
        }

        private static void UserValidation(string username)
        {
            foreach (var character in username)
            {
                if (!char.IsLetterOrDigit(character) &&
                    character != '-' &&
                    character != '_')
                {
                    return;
                }
            }
            if (username.Length >= 3 &&
                username.Length <= 16)
            {
                Console.WriteLine(username);
            }

        }
    }
}
