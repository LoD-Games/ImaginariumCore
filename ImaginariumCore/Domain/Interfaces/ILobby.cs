using System;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILobby
    {
        void Add(string playerId);
        int Size { get; }
        GameType GameType { get; set; }
        bool HasPlaces { get; }
        Guid Id { get; }
    }
}
