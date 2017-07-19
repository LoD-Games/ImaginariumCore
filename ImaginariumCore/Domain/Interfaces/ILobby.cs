using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILobby
    {
        void Add(string playerToken);
        int Size { get; }
        GameType GameType { get; set; }
        bool HasPlaces { get; }
        Guid Token { get; }
        IList<Player> Players { get; }
    }
}
