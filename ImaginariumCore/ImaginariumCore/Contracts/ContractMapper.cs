using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using ImaginariumCore.Contracts.Output;

namespace ImaginariumCore.Contracts
{
    public class ContractMapper
    {
        public UpdatedLobby ToUpdate(IEnumerable<Player> players)
        {
            IList<string> tokens  = new List<string>();
            foreach (var player in players)
            {
                tokens.Add(player.Token);
            }
            return new UpdatedLobby(){Players = tokens};
        }

        public LobbyTokenValueObject WrapToken(Guid lobbyToken)
        {
            return new LobbyTokenValueObject(lobbyToken);
        }
    }
}
