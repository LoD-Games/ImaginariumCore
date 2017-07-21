using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DomainTests
{
    [TestClass]
    public class CardDistributorTests
    {
        [TestMethod]
        public void CreatingCardDistributor()
        {
            DeckSettings deckSettings = new DeckSettings();
            Assert.IsTrue(DeckSettings.SizeToCount.Count.Equals(4));
        }

        [TestMethod]
        public void GetCardTest()
        {
            int lobbySize = 4;
            DeckSettings deckSettings = new DeckSettings();
            Deck deck = new Deck(lobbySize,DeckSettings.CountOfCards(lobbySize));
            IList<int> swapDeck = new List<int>();
            while (!deck.CardDeck.Count.Equals(0))
            {
                int card = deck.GetCard();
                Assert.IsTrue(!swapDeck.Contains(card));
                swapDeck.Add(card);
            }
            Assert.IsTrue(swapDeck.Count.Equals(DeckSettings.CountOfCards(lobbySize)));
        }
    }
}
