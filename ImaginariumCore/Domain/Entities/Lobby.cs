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
            Token = Guid.NewGuid();
            _players = new List<Player>(size);
        }

        public void Add(string playerToken)
        {
            if (HasPlaces)
            {
                _players.Add(new Player(playerToken));
            }
        }

        public int Size { get; }
        public GameType GameType { get; set; }
        public bool HasPlaces => Size - _players.Count > 0;
        public Guid Token { get; }

        public IList<Player> Players => _players;
    }
}