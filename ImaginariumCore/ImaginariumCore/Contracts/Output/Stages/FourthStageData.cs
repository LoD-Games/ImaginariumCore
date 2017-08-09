using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class FourthStageData : IWrapper
    {
        public FourthStageData(ILobby lobby)
        {
            Stage = lobby.Stage;
        }
        public int Stage { get; set; }
    }
}