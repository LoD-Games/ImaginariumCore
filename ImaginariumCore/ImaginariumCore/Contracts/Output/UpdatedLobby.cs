using System;
using System.Collections.Generic;

namespace ImaginariumCore.Contracts.Output
{
    public class UpdatedLobby
    {
        public IList<TokenAndNickName> Players { get; }

        public UpdatedLobby(IList<TokenAndNickName> players)
        {
            Players = players;
        }
    }
}