using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Lobby : ILobby
    {
        private IList<Player> _players;
        private Deck _deck;
        private int _mainPlayer;
        private IList<Score> _scores;

        public Lobby(int size, GameType type)
        {
            Size = size;
            GameType = type;
            Token = Guid.NewGuid();
            _players = new List<Player>(size);
            _deck = new Deck(size,DeckSettings.CountOfCards(size));
            Stage = 0;
            _mainPlayer = 0;
            _scores = new List<Score>(size);
        }

        public void Add(string playerToken, string nickName)
        {
            if (HasPlaces)
            {
                var player = new Player(playerToken, nickName);
                for (int i = 0; i < 6; i++)
                {
                    player.Cards.Add(_deck.GetCard());
                }
                _players.Add(player);
                _scores.Add(new Score(playerToken));
                if (!HasPlaces)
                {
                    Stage++;
                }
            }
        }

        public int Size { get; }
        public GameType GameType { get; set; }
        public bool HasPlaces => Size - _players.Count > 0;
        public Guid Token { get; }
        
        public IList<Player> Players => _players;
        public int Stage { get; private set; }
        public string MainPlayer => _players[_mainPlayer].Token;
        public IList<Score> Scores => _scores;
    }
}