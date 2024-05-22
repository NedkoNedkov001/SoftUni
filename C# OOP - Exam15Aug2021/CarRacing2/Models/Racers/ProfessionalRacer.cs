using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int drivingExperienceIncrease = 10;
        private const int startingExperience = 30;
        private const string racingBehavior = "strict";
        private const double racingBehaviorMultiplier = 1.2;
        public ProfessionalRacer(string username, ICar car) 
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
