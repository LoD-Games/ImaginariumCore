using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class LobbyManager : ILobbyManager
    {

        private IProducerConsumerCollection<ILobby> _lobbies;

        public LobbyManager()
        {
            _lobbies = new ConcurrentBag<ILobby>();
        }

        public Guid AddPlayer(string playerToken, GameType type, int size)
        {
            var freeLobby = _lobbies.SingleOrDefault(lobby => lobby.GameType == type && lobby.Size == size && lobby.HasPlaces);
            if (freeLobby is null)
            {
                freeLobby = new Lobby(size,type);
                _lobbies.TryAdd(freeLobby);
            }
            freeLobby.Add(playerToken);
            return freeLobby.Token;
        }

        public IList<Player> UpdateLobby(Guid lobbyToken)
        {
            return _lobbies.SingleOrDefault(entity => entity.Token.Equals(lobbyToken)).Players;
        }
    }
}
