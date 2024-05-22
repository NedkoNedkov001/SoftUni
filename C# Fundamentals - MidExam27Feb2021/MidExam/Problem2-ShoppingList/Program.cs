using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2_ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryList = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Go Shopping!")
                {
                    break;
                }

                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Urgent")
                {
                    UrgentItem(groceryList, command[1]);
                }
                else if (command[0] == "Unnecessary")
                {
                    UnnecessaryItem(groceryList, command[1]);
                }
                else if (command[0] == "Correct")
                {
                    CorrectItem(groceryList, command[1], command[2]);
                }
                else if (command[0] == "Rearrange")
                {
                    RearrangeItem(groceryList, command[1]);
                }
            }
            Console.WriteLine(string.Join(", ", groceryList));
        }

        private static void RearrangeItem(List<string> groceryList, string item)
        {
            if (groceryList.Contains(item))
            {
                groceryList.Remove(item);
                groceryList.Add(item);
            }
        }

        private static void CorrectItem(List<string> groceryList, string oldItem, string newItem)
        {
            if (groceryList.Contains(oldItem))
            {
                groceryList[groceryList.IndexOf(oldItem)] = newItem;
            }
        }

        private static void UnnecessaryItem(List<string> groceryList, string item)
        {
            if (groceryList.Contains(item))
            {
                groceryList.Remove(item);
            }
        }

        private static void UrgentItem(List<string> groceryList, string item)
        {
            if (groceryList.Contains(item))
            {
                return;
            }
            groceryList.Insert(0, item);
        }
    }
}
