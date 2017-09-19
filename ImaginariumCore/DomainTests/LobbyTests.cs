using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using ImaginariumCore.Contracts;
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
            catch (Exception)
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
            catch (Exception)
            {
                
            }

            Assert.IsTrue(!lobby.Text.Equals(text));
        }

        [TestMethod]
        public void SetTextAndCardButPlayerisReady()
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
            mainPlayer.Ready = true;
            try
            {
                lobby.SetCard(mainPlayer.Cards[0], text, mainPlayer.Token);
            }
            catch (Exception e)
            {
                Assert.IsNotNull(e);
            }

            Assert.IsTrue(!lobby.Text.Equals(text));
        }

        [TestMethod]
        public void SetTextAndCardFromMain()
        {
            var text = "good";
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
            lobby.SetCard(mainPlayer.Cards[0] ,text , mainPlayer.Token );
            Assert.IsTrue(lobby.Text.Equals(text) && mainPlayer.Cards.Count.Equals(5) && mainPlayer.Ready);
        }

        [TestMethod]
        public void SetCardWithoutTextByMainPlayer()
        {
            var text = "fail";
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
                lobby.SetCard(usualPlayer.Cards[0] , mainPlayer.Token);
            }
            catch (Exception)
            {
                
            }
            Assert.IsTrue(!lobby.Text.Equals(text) && usualPlayer.Cards.Count.Equals(6));
        }

        [TestMethod]
        public void SetCardAnotherCardFromUsualPlayer()
        {
            DeckSettings deckSettings = new DeckSettings();
            ILobby lobby = new Lobby(4, GameType.Usual);
            string[] tokens = { "1", "2", "3", "4" };
            foreach (var token in tokens)
            {
                lobby.Add(token, token);
            }
            var createdPlayers = lobby.Players;
            var firstPlayer = createdPlayers[1];
            var secondPlayer = createdPlayers[2];
            try
            {
                lobby.SetCard(firstPlayer.Cards[0] , secondPlayer.Token);
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(firstPlayer.Cards.Count.Equals(6) && firstPlayer.Card.Equals(0) && firstPlayer.Ready.Equals(false));
        }

        [TestMethod]
        public void SetCardFromUsualPlayerWhoIsReady()
        {
            DeckSettings deckSettings = new DeckSettings();
            ILobby lobby = new Lobby(4, GameType.Usual);
            string[] tokens = { "1", "2", "3", "4" };
            foreach (var token in tokens)
            {
                lobby.Add(token, token);
            }
            var createdPlayers = lobby.Players;
            var firstPlayer = createdPlayers[1];
            firstPlayer.Ready = true;
            try
            {
                lobby.SetCard(firstPlayer.Cards[0], firstPlayer.Token);
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(firstPlayer.Card.Equals(0) && firstPlayer.Cards.Count.Equals(6));
        }

        [TestMethod]
        public void SetCardWhenArgumentsAreOk()
        {
            DeckSettings deckSettings = new DeckSettings();
            var contractMapper = new ContractMapper();
            ILobby lobby = new Lobby(4, GameType.Usual);
            string[] tokens = { "1", "2", "3", "4" };
            foreach (var token in tokens)
            {
                lobby.Add(token, token);
            }
            var createdPlayers = lobby.Players;
            var secondPlayer = createdPlayers[1];
            var mainPlayer = createdPlayers.SingleOrDefault(player => player.Token.Equals(lobby.MainPlayer));
            lobby.SetCard(mainPlayer.Cards[0],"ok",mainPlayer.Token);
            Assert.IsTrue(lobby.Text.Equals("ok") && mainPlayer.Ready.Equals(true));
            foreach (var createdPlayer in createdPlayers)
            {
                contractMapper.MapToStageData(createdPlayer.Token, lobby);
            }
            lobby.SetCard(secondPlayer.Cards[0] , secondPlayer.Token);
            Assert.IsTrue(lobby.Stage.Equals(2));
            Assert.IsTrue(secondPlayer.Ready &&
                !secondPlayer.Card.Equals(0) && 
                !secondPlayer.Cards.Contains(secondPlayer.Card) &&
                secondPlayer.Cards.Count.Equals(5));
        }

        [TestMethod]
        public void AllPlayersCanSetCardAndLobbyStafeIs3()
        {
            DeckSettings deckSettings = new DeckSettings();
            var contractMapper = new ContractMapper();
            ILobby lobby = new Lobby(4, GameType.Usual);
            string[] tokens = { "1", "2", "3", "4" };
            foreach (var token in tokens)
            {
                lobby.Add(token, token);
            }
            var createdPlayers = lobby.Players;
            var secondPlayer = createdPlayers[1];
            var thirdPlayer = createdPlayers[2];
            var fourthPlayer = createdPlayers[3];
            var mainPlayer = createdPlayers.SingleOrDefault(player => player.Token.Equals(lobby.MainPlayer));
            lobby.SetCard(mainPlayer.Cards[0], "ok", mainPlayer.Token);
            foreach (var createdPlayer in createdPlayers)
            {
                contractMapper.MapToStageData(createdPlayer.Token, lobby);
            }
            lobby.SetCard(secondPlayer.Cards[0],secondPlayer.Token);
            lobby.SetCard(thirdPlayer.Cards[0],thirdPlayer.Token);
            lobby.SetCard(fourthPlayer.Cards[0],fourthPlayer.Token);
            Assert.IsTrue(lobby.Stage.Equals(3));
        }

        [TestMethod]
        public void AllPlayersCanVoteAndStageEquals4()
        {
            DeckSettings deckSettings = new DeckSettings();
            var contractMapper = new ContractMapper();
            ILobby lobby = new Lobby(4, GameType.Usual);
            string[] tokens = { "1", "2", "3", "4" };
            foreach (var token in tokens)
            {
                lobby.Add(token, token);
            }
            var createdPlayers = lobby.Players;
            var secondPlayer = createdPlayers[1];
            var thirdPlayer = createdPlayers[2];
            var fourthPlayer = createdPlayers[3];
            var mainPlayer = createdPlayers.SingleOrDefault(player => player.Token.Equals(lobby.MainPlayer));
            lobby.SetCard(mainPlayer.Cards[0], "ok", mainPlayer.Token);
            foreach (var createdPlayer in createdPlayers)
            {
                contractMapper.MapToStageData(createdPlayer.Token, lobby);
            }
            lobby.SetCard(secondPlayer.Cards[0], secondPlayer.Token);
            lobby.SetCard(thirdPlayer.Cards[0], thirdPlayer.Token);
            lobby.SetCard(fourthPlayer.Cards[0], fourthPlayer.Token);
            lobby.SetCard(lobby.Players[0].Card, secondPlayer.Token);
            lobby.SetCard(lobby.Players[1].Card, thirdPlayer.Token);
            lobby.SetCard(lobby.Players[2].Card, fourthPlayer.Token);
            Assert.IsTrue(lobby.Stage.Equals(4));

        }


    }
}
