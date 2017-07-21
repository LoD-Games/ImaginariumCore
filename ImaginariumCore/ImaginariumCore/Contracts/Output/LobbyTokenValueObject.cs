using System;

namespace ImaginariumCore.Contracts.Output
{
    public class LobbyTokenValueObject
    {
        private readonly Guid lobbyToken;

        public Guid LobbyToken => lobbyToken;

        public LobbyTokenValueObject(Guid lobbyToken)
        {
            this.lobbyToken = lobbyToken;
        }
    }
}