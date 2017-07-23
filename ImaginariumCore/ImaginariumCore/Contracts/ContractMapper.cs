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
            IList<TokenAndNickName> tokensAndNickNames  = new List<TokenAndNickName>();
            foreach (var player in players)
            {
                tokensAndNickNames.Add(new TokenAndNickName(player.Token , player.NickName));
            }
            return new UpdatedLobby(tokensAndNickNames);
        }

        public LobbyTokenValueObject WrapToken(Guid lobbyToken)
        {
            return new LobbyTokenValueObject(lobbyToken);
        }
    }
}
