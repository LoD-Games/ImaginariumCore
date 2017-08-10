using System.Collections.Generic;

namespace Domain.Entities
{
    public class Player
    {
        public string Token { get; }

        public IList<int> Cards { get; }

        public string NickName { get; }

        public bool Ready { get; set; }

        public int Card { get; set; }

        public int Vote { get; set; }

        public Player(string token, string nickName = "default")
        {
            Token = token;
            NickName = nickName;
            Cards = new List<int>();
            Ready = false;
            Card = 0;
            Vote = 0;
        }

    }
}
