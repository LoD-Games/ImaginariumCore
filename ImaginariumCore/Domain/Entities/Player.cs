using System.Collections.Generic;

namespace Domain.Entities
{
    public class Player
    {
        public string Token { get; }

        public IList<int> Cards { get; }

        public Player(string token)
        {
            Token = token;
            Cards = new List<int>();
        }
    }
}
