using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class ThirdStageData: IWrapper
    {
        public ThirdStageData(ILobby lobby)
        {
            Stage = lobby.Stage;
        }
        public int Stage { get; set; }
    }
}
