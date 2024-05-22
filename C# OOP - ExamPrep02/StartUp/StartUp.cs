using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            Family family = new Family();




            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                people.Add(person);
                family.AddMember(person);
            }
            List<Person> orderedPeople = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();
            foreach (var person in orderedPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}
