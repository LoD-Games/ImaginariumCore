using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Lobby : ILobby
    {
        private IList<Player> _players;
        public Lobby(int size, GameType type)
        {
            Size = size;
            GameType = type;
            Id = Guid.NewGuid();
            _players = new List<Player>(size);
        }

        public void Add(string playerId)
        {
            if (HasPlaces)
            {
                _players.Add(new Player(playerId));
            }
        }

        public int Size { get; }
        public GameType GameType { get; set; }
        public bool HasPlaces => Size - _players.Count > 0;
        public Guid Id { get; }
    }
}