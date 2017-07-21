using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class LobbyTests
    {
        [TestMethod]
        public void AddPlayerToLobby()
        {
            DeckSettings deckSettings = new DeckSettings();
            ILobby lobby = new Lobby(4, GameType.Usual);
            for (int i = 0; i < lobby.Size; i++)
            {
                Assert.IsTrue(lobby.HasPlaces);
                lobby.Add(i.ToString());
            }
            Assert.IsFalse(lobby.HasPlaces);
            lobby.Add("5");
        }

    }
}
