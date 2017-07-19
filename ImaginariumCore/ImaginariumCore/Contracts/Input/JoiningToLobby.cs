using System;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace ImaginariumCore.Contracts.Input
{
    public class JoiningToLobby
    {
        public GameType GameType { get; set ; }

        [Range(4,6)]
        public int Size { get; set; }

        public string PlayerToken { get; set; }

        public JoiningToLobby(GameType gameType)
        {
            if (!gameType.Equals(GameType.Usual) && 
                !gameType.Equals(GameType.Custom) && 
                !gameType.Equals(GameType.Fast))
            {
                throw new ArgumentException("wrong type of game");
            }
            GameType = gameType;
        }
    }
}