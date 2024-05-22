using System;
using System.Collections.Generic;

namespace Problem3_ChatLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>(10);

            //string messageToPin = "";
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Chat")
                {
                    AddMessage(messages, command[1]);
                }
                else if (command[0] == "Delete")
                {
                    DeleteMessage(messages, command[1]);
                }
                else if (command[0] == "Edit")
                {
                    EditMessage(messages, command[1], command[2]);
                }
                else if (command[0] == "Pin")
                {
                    // messageToPin = command[1];
                    PinMessage(messages, command[1]);
                }
                else if (command[0] == "Spam")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        messages.Add(command[i]);
                    }
                }
            }
            //PinMessage(messages, messageToPin)
        }

        private static void PinMessage(List<string> messages, string v1)
        {
            messages.Remove(v1);
            messages.Add(v1);
        }

        private static void EditMessage(List<string> messages, string v1, string v2)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i] == v1)
                {
                    messages[i] = v2;
                }
            }
        }

        private static void DeleteMessage(List<string> messages, string v)
        {
            messages.Remove(v);
        }

        private static void AddMessage(List<string> messages, string v)
        {
            messages.Add(v);
        }
    }
}
