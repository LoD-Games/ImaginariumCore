using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Lobby : ILobby
    {
        private IList<Player> _players;
        private Deck _deck;

        public Lobby(int size, GameType type)
        {
            Size = size;
            GameType = type;
            Token = Guid.NewGuid();
            _players = new List<Player>(size);
            _deck = new Deck(size,DeckSettings.CountOfCards(size));
        }

        public void Add(string playerToken)
        {
            if (HasPlaces)
            {
                var player = new Player(playerToken);
                for (int i = 0; i < 6; i++)
                {
                    player.Cards.Add(_deck.GetCard());
                }
                _players.Add(player);
            }
        }

        public int Size { get; }
        public GameType GameType { get; set; }
        public bool HasPlaces => Size - _players.Count > 0;
        public Guid Token { get; }
        
        public IList<Player> Players => _players;
    }
}