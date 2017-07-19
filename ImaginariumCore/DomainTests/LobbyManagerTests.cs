using System;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class LobbyManagerTests
    {
        [TestMethod]
        public void AddPlayerToLobbyFromManager()
        {
            ILobbyManager lobbyManager = new LobbyManager();
            var lobbyId = Guid.Empty;
            lobbyId = lobbyManager.AddPlayer("0", GameType.Usual, 4);
            for (int i = 1; i < 4; i++)
            {
                var returnedId = lobbyManager.AddPlayer(i.ToString(), GameType.Usual, 4);
                Assert.IsTrue(returnedId.Equals(lobbyId));
            }
            var newLobbyId = lobbyManager.AddPlayer("5", GameType.Usual, 4);
            Assert.IsFalse(newLobbyId.Equals(lobbyId));
            var lobbyIdForCustomGame = lobbyManager.AddPlayer("6", GameType.Custom, 4);
            Assert.IsFalse(lobbyId.Equals(lobbyIdForCustomGame) && lobbyIdForCustomGame.Equals(newLobbyId));
            var lobbyIdWithNewSizeAndGameTypeIsUsual = lobbyManager.AddPlayer("7", GameType.Usual, 5);
            Assert.IsFalse(lobbyIdWithNewSizeAndGameTypeIsUsual.Equals(lobbyIdForCustomGame) && 
                lobbyIdWithNewSizeAndGameTypeIsUsual.Equals(newLobbyId) && 
                lobbyIdWithNewSizeAndGameTypeIsUsual.Equals(lobbyId));
        }
    }
}
