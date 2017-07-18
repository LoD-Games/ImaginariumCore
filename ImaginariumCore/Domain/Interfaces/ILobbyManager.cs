using System;
using Domain.Entities;

namespace Domain.Interfaces
{
    interface ILobbyManager
    {
        Guid AddPlayer(string playerId, GameType type, int size);
    }
}
