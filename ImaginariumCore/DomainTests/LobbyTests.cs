using System;
using System.Linq;
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

        [TestMethod]
        public void SetTextFromUsualPlayer()
        {
            DeckSettings deckSettings = new DeckSettings();
            ILobby lobby = new Lobby(4,GameType.Usual);
            string[] tokens = {"1", "2", "3", "4"};
            foreach (var token in tokens)
            {
                lobby.Add(token , token);
            }
            var createdPlayers = lobby.Players;
            var mainPlayer = createdPlayers.SingleOrDefault(player => player.Token.Equals(lobby.MainPlayer));
            var usualPlayer = createdPlayers[1];
            try
            {
                lobby.SetCard(usualPlayer.Cards[0] , "this is fail" , usualPlayer.Token);
            }
            catch (Exception e)
            {
               
            }
            Assert.IsTrue(lobby.Text.Equals(String.Empty));
        }

        [TestMethod]
        public void SetTextAndFakeCard()
        {
            var text = "this is fail";
            DeckSettings deckSettings = new DeckSettings();
            ILobby lobby = new Lobby(4, GameType.Usual);
            string[] tokens = { "1", "2", "3", "4" };
            foreach (var token in tokens)
            {
                lobby.Add(token, token);
            }
            var createdPlayers = lobby.Players;
            var mainPlayer = createdPlayers.SingleOrDefault(player => player.Token.Equals(lobby.MainPlayer));
            var usualPlayer = createdPlayers[1];
            try
            {
                lobby.SetCard(usualPlayer.Cards[0],text , mainPlayer.Token);
            }
            catch (Exception e)
            {
                
            }

            Assert.IsTrue(!lobby.Text.Equals(text));
        }
    }
}
