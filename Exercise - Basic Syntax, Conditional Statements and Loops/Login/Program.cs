using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Concat(username.Reverse());

            int passwordAttempts = 0;
            bool correctPassword = false;
            bool isBlocked = false;

            string passwordTry = "";
            while (correctPassword != true)
            {
                passwordTry = Console.ReadLine();
                if (passwordTry == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    correctPassword = true;
                }
                else if (passwordAttempts < 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    passwordAttempts++;
                }
                else if (passwordAttempts == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
            }
        }
    }
}
