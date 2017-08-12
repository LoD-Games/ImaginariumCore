using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            Text = String.Empty;
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
        public int AmountOfCards => _deck.AmountOfCards;
        public void SetCard(int card, string text, string playerToken)
        {
            var mainPlayer = Players.SingleOrDefault(player => player.Token.Equals(playerToken));
            if (!mainPlayer.Token.Equals(MainPlayer) 
                || !mainPlayer.Cards.Contains(card)
                || mainPlayer.Ready.Equals(true)
                || !Stage.Equals(1))
            {
                throw new HttpRequestException("invalid token of main player or this card was used or player doesn't have this card");
            }
            Text = text;
            mainPlayer.Card = card;
            mainPlayer.Cards.Remove(card);
            mainPlayer.Ready = true;
        }

        public void SetCard(int card, string playerToken)
        {
            var currentPlayer = Players.SingleOrDefault(player => player.Token.Equals(playerToken));
            if (!currentPlayer.Cards.Contains(card) 
                || currentPlayer.Ready.Equals(true) 
                || currentPlayer.Token.Equals(MainPlayer))
            {
                throw new HttpRequestException("player doesn't have this card or ready for next stage or it's main player");
            }
            switch (Stage)
            {
                case 2:
                {
                    currentPlayer.Card = card;
                    currentPlayer.Cards.Remove(card);
                    break;
                }
                case 3:
                {
                    currentPlayer.Vote = card;
                    break;
                }
            }
            currentPlayer.Ready = true;
        }

        public string Text { get; set; }
        public void TryGoToNextStage()
        {
            if (Players.All(player => player.Ready))
            {
                Stage += 1;
                if (Stage>4)
                {
                    Stage = 1;
                    AddCardsToPlayers();
                    NewGame();
                    if (Players.All(player => player.Cards.Count.Equals(0)))
                    {
                        Stage = 0;
                    }
                }
                foreach (var player in Players)
                {
                    player.Ready = false;
                }
                if (Stage.Equals(2) || Stage.Equals(3))
                {
                    Players.SingleOrDefault(player => player.Token.Equals(MainPlayer)).Ready = true;
                }

            }
        }

        private void AddCardsToPlayers()
        {
            if (_deck.HasCards)
            {
                foreach (var player in Players)
                {
                    player.Cards.Add(_deck.GetCard());
                }
            }
        }

        private void NewGame()
        {
            SetScore();
            _mainPlayer += 1;
            if (_mainPlayer.Equals(Players.Count))
            {
                _mainPlayer = 0;
            }
            foreach (var player in Players)
            {
                player.Card = player.Vote = 0;
            }
        }

        private void SetScore()
        {
            
        }
    }
}