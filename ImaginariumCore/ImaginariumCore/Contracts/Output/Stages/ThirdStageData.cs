using System.Collections.Generic;
using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class ThirdStageData: IWrapper
    {
        public ThirdStageData(ILobby lobby)
        {
            Stage = lobby.Stage;
            DonePlayers = new List<string>();
            Cards = new List<int>();
            foreach (var player in lobby.Players)
            {
                if (player.Ready)
                {
                    DonePlayers.Add(player.Token);
                    if (!player.Cards.Equals(0))
                    {
                        Cards.Add(player.Card);
                    }
                }
            }
        }
        public int Stage { get; set; }
        public IList<int> Cards { get; set; }
        public IList<string> DonePlayers { get; set; }
    }
}
