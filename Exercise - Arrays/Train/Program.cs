using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] people = new int[wagons];
            int peopleSum = 0;
            for (int i = 0; i < wagons; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                peopleSum += people[i];
            }
            for (int i = 0; i < people.Length; i++)
            {
                Console.Write($"{people[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(peopleSum);
        }
    }
}
