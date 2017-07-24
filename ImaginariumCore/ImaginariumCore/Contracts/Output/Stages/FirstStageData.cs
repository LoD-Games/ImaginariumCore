using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class FirstStageData : IWrapper
    {
        public FirstStageData(ILobby lobby , string playerToken)
        {
            Cards = lobby.Players.SingleOrDefault(player => player.Token.Equals(playerToken)).Cards;
            Scores = lobby.Scores;
            foreach (var lobbyPlayer in lobby.Players)
            {
                
            }
        }

        public IList<int> Cards;
        public IList<Score> Scores;
        public IList<string> DonePlayers;
    }
}
