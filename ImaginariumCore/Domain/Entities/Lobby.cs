using System;
using Domain.Interfaces;

namespace Domain.Entities
{
     public class Lobby : ILobby
     {

         public Lobby(int size , GameType type)
         {
             Size = size;
             GameType = type;
             Id = Guid.NewGuid();
         }

        public void Add(string playerId)
         {
             throw new System.NotImplementedException();
         }

         public int Size { get; set; }
         public GameType GameType { get; set; }
         public bool HasPlaces { get; }
         public Guid Id { get; }
     }
}
