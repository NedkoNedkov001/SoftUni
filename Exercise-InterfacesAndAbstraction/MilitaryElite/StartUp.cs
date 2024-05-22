using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> result = new List<ISoldier>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputTokens = input.Split();
                string soldierType = inputTokens[0];
                int id = int.Parse(inputTokens[1]);
                string firstName = inputTokens[2];
                string lastName = inputTokens[3];


                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(inputTokens[4]);
                    result.Add(new Private(id, firstName, lastName, salary));
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(inputTokens[4]);
                    result.Add(new Spy(id, firstName, lastName, codeNumber));
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputTokens[4]);

                    List<IPrivate> privates = new List<IPrivate>();
                    foreach (var currentId in inputTokens[5..])
                    {
                        var currentPrivate = (IPrivate)result
                            .FirstOrDefault(x => x.ID == int.Parse(currentId));
                        privates.Add(currentPrivate);
                    }
                    result.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(inputTokens[4]);
                    Enum.TryParse(inputTokens[5], false, out SoldierCorpEnum corp);

                    if (corp == default)
                    {
                        continue;
                    }
                    List<IRepair> repairs = new List<IRepair>();

                    for (int i = 6; i < inputTokens.Length; i += 2)
                    {
                        var partName = inputTokens[i];
                        var workedHours = int.Parse(inputTokens[i + 1]);

                        repairs.Add(new Repair(partName, workedHours));
                    }
                    result.Add(new Engineer(id, firstName, lastName, salary, corp, repairs));
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(inputTokens[4]);
                    Enum.TryParse(inputTokens[5], false, out SoldierCorpEnum corp);

                    if (corp == default)
                    {
                        continue;
                    }
                    List<IMission> missions = new List<IMission>();
                    for (int i = 6; i <inputTokens.Length-1; i++)
                    {
                        var missionState = inputTokens[i + 1];
                        if (missionState != "inProgress" && missionState != "Finished")
                        {
                            continue;
                        }

                        string missionName = inputTokens[i];
                        Enum.TryParse(missionState, false, out MissionStateEnum state);
                        if (state != default)
                        {
                            IMission mission = new Mission(missionName, state);
                            missions.Add(mission);
                        }


                    }

                    result.Add(new Commando(id, firstName, lastName, salary, corp, missions));
                }
            }

            foreach (var soldier in result)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
