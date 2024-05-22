using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int drivingExperienceIncrease = 5;
        private const int startingExperience = 10;
        private const string racingBehavior = "aggressive";
        private const double racingBehaviorMultiplier = 1.1;

        public StreetRacer(string username, ICar car) 
            : base(username, racingBehavior, startingExperience, car)
        {
        }

        //Possible error
        public override void Race()
        {
            base.Race();
            this.DrivingExperience += drivingExperienceIncrease;
        }
    }
}
