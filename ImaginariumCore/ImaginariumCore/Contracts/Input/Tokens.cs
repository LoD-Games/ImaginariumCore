using System;

namespace ImaginariumCore.Contracts.Input
{
    public class Tokens
    {
        public Guid LobbyToken { get; }
        public string PlayerToken { get; }

        public Tokens(Guid lobbyToken, string playerToken)
        {
            LobbyToken = lobbyToken;
            PlayerToken = playerToken;
        }
    }
}
