using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILobby
    {
        void Add(string playerId);
        int Size { get; set; }
        GameType GameType { get; set; }
    }
}
