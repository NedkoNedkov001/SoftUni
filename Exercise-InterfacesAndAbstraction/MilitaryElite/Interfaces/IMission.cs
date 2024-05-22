using MilitaryElite.Enumerations;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }

        public MissionStateEnum MissionState { get; }

        public void CompleteMission();
    }
}