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
            string nick = "default";
            DeckSettings deckSettings = new DeckSettings();
            ILobbyManager lobbyManager = new LobbyManager();
            var lobbyId = Guid.Empty;
            lobbyId = lobbyManager.AddPlayer("0", GameType.Usual, 4 , nick);
            for (int i = 1; i < 4; i++)
            {
                var returnedId = lobbyManager.AddPlayer(i.ToString(), GameType.Usual, 4,nick);
                Assert.IsTrue(returnedId.Equals(lobbyId));
            }
            var newLobbyId = lobbyManager.AddPlayer("5", GameType.Usual, 4,nick);
            Assert.IsFalse(newLobbyId.Equals(lobbyId));
            var lobbyIdForCustomGame = lobbyManager.AddPlayer("6", GameType.Custom, 4,nick);
            Assert.IsFalse(lobbyId.Equals(lobbyIdForCustomGame) && lobbyIdForCustomGame.Equals(newLobbyId));
            var lobbyIdWithNewSizeAndGameTypeIsUsual = lobbyManager.AddPlayer("7", GameType.Usual, 5,nick);
            Assert.IsFalse(lobbyIdWithNewSizeAndGameTypeIsUsual.Equals(lobbyIdForCustomGame) && 
                lobbyIdWithNewSizeAndGameTypeIsUsual.Equals(newLobbyId) && 
                lobbyIdWithNewSizeAndGameTypeIsUsual.Equals(lobbyId));
        }

        [TestMethod]
        public void TryAddTwoPlayersWithSameTokens()
        {
            //arrange
            string nick = "default";
            DeckSettings deckSettings = new DeckSettings();
            ILobbyManager lobbyManager = new LobbyManager();
            var lobbyToken = Guid.Empty;
            var players = new[] {new Player("1",nick),
                                 new Player("2", nick),
                                 new Player("3",nick),
                                 new Player("4",nick),
            };
            foreach (var player in players)
            {
                lobbyToken = lobbyManager.AddPlayer(player.Token, GameType.Usual, 4, player.NickName);
            }
            //Act
            var tokenFromManager = lobbyManager.AddPlayer(players[0].Token, GameType.Usual, 4, players[0].NickName);
            Assert.IsTrue(tokenFromManager.Equals(lobbyToken));

        }

        [TestMethod]
        public void AddPlayerWithAnotherNickName()
        {
            //arrange
            string nick = "default";
            DeckSettings deckSettings = new DeckSettings();
            ILobbyManager lobbyManager = new LobbyManager();
            var lobbyToken = Guid.Empty;
            var players = new[] {new Player("1",nick),
                new Player("2", nick),
                new Player("3",nick),
                new Player("4",nick),
            };
            foreach (var player in players)
            {
                lobbyToken = lobbyManager.AddPlayer(player.Token, GameType.Usual, 4, player.NickName);
            }
            //Act
            var tokenFromManager = lobbyManager.AddPlayer("5", GameType.Usual, 4, nick);
            Assert.IsFalse(tokenFromManager.Equals(lobbyToken));

        }
    }
}
