using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();

            string[] dateOne = Console.ReadLine().Split();
            string[] dateTwo = Console.ReadLine().Split();

            Console.WriteLine(dateModifier.FindDifference(dateOne, dateTwo)); 
        }
    }
}
