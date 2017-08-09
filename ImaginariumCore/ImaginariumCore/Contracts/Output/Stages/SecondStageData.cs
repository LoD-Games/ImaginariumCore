using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class SecondStageData : IWrapper
    {
        public SecondStageData(ILobby lobby)
        {
            Stage = lobby.Stage;
        }
        public int Stage { get; set; }
    }
}
