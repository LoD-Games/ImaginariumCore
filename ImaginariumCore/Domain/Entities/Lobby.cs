using Domain.Interfaces;

namespace Domain.Entities
{
     public class Lobby : ILobby
     {
         public void Add(string playerId)
         {
             throw new System.NotImplementedException();
         }

         public int Size { get; set; }
         public GameType GameType { get; set; }
     }
}
