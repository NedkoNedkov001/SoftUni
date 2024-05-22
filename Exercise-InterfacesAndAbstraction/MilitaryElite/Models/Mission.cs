using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }

        public string CodeName { get; }

        public MissionStateEnum MissionState { get; private set; }

        public void CompleteMission()
        {
            this.MissionState = MissionStateEnum.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.MissionState}";
        }
    }
}
