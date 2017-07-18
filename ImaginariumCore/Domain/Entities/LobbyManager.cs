using System;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class LobbyManager : ILobbyManager
    {
        public Guid AddPlayer(string playerId, GameType type, int size)
        {
            throw new NotImplementedException();
        }
    }
}
