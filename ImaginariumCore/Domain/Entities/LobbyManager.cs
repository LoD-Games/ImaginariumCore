using System;
using System.Collections.Concurrent;
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

        public Guid AddPlayer(string playerId, GameType type, int size)
        {
            if (size<4 || size >6)
            {
                throw new ArgumentException("size values can be 4,5,6 only");
            }
            var freeLobby = _lobbies.SingleOrDefault(lobby => lobby.GameType == type && lobby.Size == size && lobby.HasPlaces);
            if (freeLobby is null)
            {
                freeLobby = new Lobby(size,type);
                _lobbies.TryAdd(freeLobby);
            }
            freeLobby.Add(playerId);
            return freeLobby.Id;
        }
    }
}
