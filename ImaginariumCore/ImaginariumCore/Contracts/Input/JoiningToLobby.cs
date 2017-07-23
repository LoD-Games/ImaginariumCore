using System;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace ImaginariumCore.Contracts.Input
{
    public class JoiningToLobby
    {
        public GameType GameType { get; set; }

        public int Size { get; set; }

        public string PlayerToken { get; set; }

        public string NickName { get; set; }

        public JoiningToLobby(GameType gameType, int size, string playerToken , string nickName = "default")
        {
            if (!gameType.Equals(GameType.Usual) &&
                 !gameType.Equals(GameType.Custom) &&
                 !gameType.Equals(GameType.Fast) || size <4 || size >7 )
            {
                throw new ArgumentException("wrong type of game");
            }
            GameType = gameType;
            Size = size;
            PlayerToken = playerToken;
            NickName = nickName;
        }
    }
}