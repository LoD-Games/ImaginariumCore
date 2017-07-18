using System;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILobbyManager
    {
        Guid AddPlayer(string playerId, GameType type, int size);
    }
}
