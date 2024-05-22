using System;
using System.Text;

namespace CaeserCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            StringBuilder encryptedMessage = new StringBuilder();
            
            foreach (char letter in message)
            {
                char encryptedLetter = (char)(letter + 3);

                encryptedMessage.Append(encryptedLetter);
            }

            Console.WriteLine(encryptedMessage);
        }
    }
}
