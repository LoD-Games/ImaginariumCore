using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class FourthStageData : IWrapper
    {
        public FourthStageData(ILobby lobby)
        {
            Stage = lobby.Stage;
            MainCard = lobby.Players.SingleOrDefault(player => player.Token.Equals(lobby.MainPlayer)).Card;
            VoteResult = new List<VoteResult>();
            lobby.TryGoToNextStage();
        }
        public int Stage { get; set; }
        public IList<VoteResult> VoteResult { get; set; }
        public int MainCard { get; set; }
        public IList<string> DonePlayers { get; set; }
    }

    public class VoteResult
    {
        public int Id { get; set; }
        public  int Cound { get; set; }
    }
}