using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Deck
    {
        public IList<int> CardDeck { get; }

        public Deck(int lobbySize , int cardsCount)
        {
            int deckSize = cardsCount;
            CardDeck = new List<int>(deckSize);
            for (var i = 0; i < deckSize; i++)
            {
                CardDeck.Add(i+1);
            }
            _random = new Random(0);
        }

        public int GetCard()
        {
            int card;
            card = CardDeck[_random.Next(CardDeck.Count)];
            CardDeck.Remove(card);
            return card;
        }

        private Random _random;

        public int AmountOfCards => CardDeck.Count;
        public bool HasCards => CardDeck.Count > 0;
    }
}
