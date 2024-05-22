using System;

namespace MidExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            const int employees = 3;

            int employee1Eff = int.Parse(Console.ReadLine());
            int employee2Eff = int.Parse(Console.ReadLine());
            int employee3Eff = int.Parse(Console.ReadLine());

            int employeesTotalEff = employee1Eff + employee2Eff + employee3Eff;

            int studentsCount = int.Parse(Console.ReadLine());

            int hoursNeeded = 0;

            int count = 1;
            while (studentsCount > 0)
            {
                if (count < 4)
                {
                    studentsCount -= employeesTotalEff;
                    count++;
                }
                else if (count == 4)
                {
                    count = 1;
                }
                hoursNeeded++;

            }

            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
