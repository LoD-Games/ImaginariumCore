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
            Stage = lobby.Stage;
            DonePlayers = new List<string>();
            var players = lobby.Players;
            Cards = players.SingleOrDefault(player => player.Token.Equals(playerToken)).Cards;
            Scores = lobby.Scores;
            foreach (var lobbyPlayer in lobby.Players)
            {
                if (lobbyPlayer.Ready)
                {
                    DonePlayers.Add(lobbyPlayer.Token);
                }
            }
            MainPlayerToken = lobby.MainPlayer;
            AmountOfCards = lobby.AmountOfCards;
        }

        public int Stage { get; set; }
        public IList<int> Cards { get; set; }
        public IList<Score> Scores { get; set; }
        public IList<string> DonePlayers { get; set; }
        public string MainPlayerToken { get; set; }
        public int AmountOfCards { get; set; }
    }
}
