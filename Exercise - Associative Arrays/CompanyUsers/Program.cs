using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] command = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string company = command[0];
                string employeeID = command[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }
                if (companies[company].Contains(employeeID))
                {
                    continue;
                }
                companies[company].Add(employeeID);
            }

            Dictionary<string, List<string>> sortedCompanies = companies
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in sortedCompanies)
            {
                Console.WriteLine(company.Key);
                foreach (var employeeID in company.Value)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}
