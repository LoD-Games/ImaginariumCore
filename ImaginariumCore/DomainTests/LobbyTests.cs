using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class LobbyTests
    {
        public string nick = "default";
        [TestMethod]
        public void AddPlayerToLobby()
        {
            DeckSettings deckSettings = new DeckSettings();
            ILobby lobby = new Lobby(4, GameType.Usual);
            for (int i = 0; i < lobby.Size; i++)
            {
                Assert.IsTrue(lobby.HasPlaces);
                lobby.Add(i.ToString(),nick);
            }
            Assert.IsFalse(lobby.HasPlaces);
            lobby.Add("5",nick);
        }

        [TestMethod]
        public void PlayersGiveCardsAfterJoiningToLobby()
        {
            DeckSettings deckSettings = new DeckSettings();
            ILobby lobby =  new Lobby(4,GameType.Usual);
            for (int i = 0; i < lobby.Size; i++)
            {
                lobby.Add(i.ToString(),nick);
            }
            foreach (var lobbyPlayer in lobby.Players)
            {
                Assert.IsTrue(lobbyPlayer.Cards.Count.Equals(6));
            }
        }

    }
}
