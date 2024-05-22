using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();
            FillContests(contests);
            FillCandidates(contests, candidates);
            RankAndPrintCandidates(candidates);
        }

        private static void RankAndPrintCandidates(Dictionary<string, Dictionary<string, int>> candidates)
        {
            //Rank candidates
            Dictionary<string, Dictionary<string, int>> bestCandidates = candidates
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            //Print candidates
            Console.WriteLine($"Best candidate is {bestCandidates.First().Key} with total {bestCandidates.First().Value.Values.Sum()} points.");
            Console.WriteLine("Ranking: ");
            foreach (var candidate in bestCandidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
        private static void FillCandidates(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> candidates)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end of submissions")
                {
                    break;
                }
                string[] candidate = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = candidate[0];
                string password = candidate[1];
                string username = candidate[2];
                int points = int.Parse(candidate[3]);

                //If contest exists and password is right
                if (contests.ContainsKey(contest) && contests[contest].Contains(password))
                {
                    //If candidate does not exist, add the candidate
                    if (!candidates.ContainsKey(username))
                    {
                        candidates.Add(username, new Dictionary<string, int>());
                    }
                    //Add contest to candidate if it does not exist
                    if (!candidates[username].ContainsKey(contest))
                    {
                        candidates[username].Add(contest, points);
                    }
                    //If candidate has completed the contest before
                    else
                    {
                        //If the candidate did better this time, update their points
                        if (candidates[username][contest] < points)
                        {
                            candidates[username][contest] = points;
                        }
                    }

                }

            }
        }
        private static void FillContests(Dictionary<string, string> contests)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end of contests")
                {
                    break;
                }
                string[] contest = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = contest[0];
                string contestPassword = contest[1];

                //Add contest with its password
                contests.Add(contestName, contestPassword);
            }
        }
    }
}
