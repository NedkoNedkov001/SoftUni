using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo, racerOne);
            }
            if (!racerTwo.IsAvailable() && racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne, racerTwo);
            }
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            double racingBehaviorOne = 0;
            double racingBehaviorTwo = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                racingBehaviorOne = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racingBehaviorOne = 1.1;
            }
            if (racerTwo.RacingBehavior == "strict")
            {
                racingBehaviorTwo = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racingBehaviorTwo = 1.1;
            }

            racerOne.Race();
            racerTwo.Race();
            double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorOne;
            double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorTwo;

            string winnerUsername = "";
            if (racerOneChance > racerTwoChance)
            {
                winnerUsername = racerOne.Username;
            }
            else if (racerOneChance < racerTwoChance)
            {
                winnerUsername = racerTwo.Username;
            }
            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerUsername);

        }
    }
}
