using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> users = new Dictionary<string, int[]>();

            int limitMsg = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] command = input
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Add":
                        AddUser(users, command[1], command[2], command[3], limitMsg);
                        break;
                    case "Message":
                        MessageUser(users, limitMsg, command[1], command[2]);
                        break;
                    case "Empty":
                        EmptyUser(users, command[1]);
                        break;
                }
            }

            Console.WriteLine($"Users count: {users.Count}");
            users = users
                .OrderByDescending(n => n.Value[1])
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} - {user.Value[0] + user.Value[1]}");
            }
        }

        private static void EmptyUser(Dictionary<string, int[]> users, string user)
        {
            if (user == "All")
            {
                for (int i = users.Count - 1; i >= 0; i--)
                {
                    users.Clear();
                }
            }
            else if (users.ContainsKey(user))
            {
                users.Remove(user);
            }
        }

        private static void MessageUser(Dictionary<string, int[]> users, int limit, string userOne, string userTwo)
        {
            if (users.ContainsKey(userOne) && users.ContainsKey(userTwo))
            {
                users[userOne][0]++;
                users[userTwo][1]++;

                if (users[userOne][0]+users[userOne][1] >= limit)
                {
                    users.Remove(userOne);
                    Console.WriteLine($"{userOne} reached the capacity!");
                }
                if (users[userTwo][0]+users[userTwo][1] >= limit)
                {
                    users.Remove(userTwo);
                    Console.WriteLine($"{userTwo} reached the capacity!");
                }
            }
        }

        private static void AddUser(Dictionary<string, int[]> users, string user, string sent, string received, int limit)
        {
            int sentMessages = int.Parse(sent);
            int receivedMessages = int.Parse(received);

            if (!users.ContainsKey(user) && sentMessages+receivedMessages < limit)
            {
                users.Add(user, new int[] { sentMessages, receivedMessages });
            }
        }
    }
}
