using System.Collections.Generic;
using Domain.Interfaces;

namespace ImaginariumCore.Contracts.Output.Stages
{
    public class SecondStageData : IWrapper
    {
        public SecondStageData(ILobby lobby)
        {
            Stage = lobby.Stage;
            Text = lobby.Text;
            DonePlayers = new List<string>();
            foreach (var player in lobby.Players)
            {
                if (player.Ready)
                {
                    DonePlayers.Add(player.Token);
                }
            }
        }
        public int Stage { get; set; }
        public string Text { get; set; }
        public IList<string> DonePlayers { get; set; }
    }
}
