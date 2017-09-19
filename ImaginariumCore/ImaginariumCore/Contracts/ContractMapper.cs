using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using ImaginariumCore.Contracts.Output;
using ImaginariumCore.Contracts.Output.Stages;

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

        public IWrapper MapToStageData(string playerToken, ILobby lobby)
        {
            IWrapper lobbyData;
            switch (lobby.Stage)
            {
                case 2:lobbyData = new SecondStageData(lobby);
                    break;
                case 3:lobbyData = new ThirdStageData(lobby);
                    break;
                case 4:lobbyData = new FourthStageData(lobby , playerToken);
                    break;
                default: lobbyData = new FirstStageData(lobby , playerToken);
                    break;
            }
            return lobbyData;
        }
    }
}
