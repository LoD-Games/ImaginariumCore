using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class FourthStageData : IWrapper
    {
        public FourthStageData(ILobby lobby , string playerToken)
        {
            Stage = lobby.Stage;
            var players = lobby.Players;
            var currentPlayer = players.SingleOrDefault(player => player.Token.Equals(playerToken));
            currentPlayer.Ready = true;
            MainCard = lobby.Players.SingleOrDefault(player => player.Token.Equals(lobby.MainPlayer)).Card;
            DonePlayers = new List<string>();
            VoteResult = lobby.VoteResults;
            foreach (var player in players)
            {
                if (player.Ready)
                {
                    DonePlayers.Add(player.Token);
                }
            }
            lobby.TryGoToNextStageAsync();
        }
        public int Stage { get; set; }
        public IList<VoteResult> VoteResult { get; set; }
        public int MainCard { get; set; }
        public IList<string> DonePlayers { get; set; }
    }
}