using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILobbyManager
    {
        Guid AddPlayer(string playerToken, GameType type, int size,string nickName);
        IList<Player> UpdateLobby(Guid lobbyToken);
        IList<ILobby> GetAll();
        void ClearAll();
        ILobby GetLobby(Guid lobbyToken);
        void SetCard(int card , string text , string playerToken, Guid lobbyToken);
        void SetCard(int card, string playerToken, Guid lobbyToken);
    }
}
