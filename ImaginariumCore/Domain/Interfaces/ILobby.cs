using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILobby
    {
        void Add(string playerToken , string nickName = "default");
        int Size { get; }
        GameType GameType { get; set; }
        bool HasPlaces { get; }
        Guid Token { get; }
        IList<Player> Players { get; }
        int Stage { get; }
        string MainPlayer { get; }
        IList<Score> Scores { get; }
        int AmountOfCards { get; }
        void SetCard(int card, string text, string playerToken);
        void SetCard(int card, string playerToken);
        string Text { get; }
        
    }
}
