using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = command[0];
                string name = command[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }

                courses[course].Add(name);
            }

            Dictionary<string, List<string>> orderedCourses = courses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);


            foreach (var course in orderedCourses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                course.Value.Sort();

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
