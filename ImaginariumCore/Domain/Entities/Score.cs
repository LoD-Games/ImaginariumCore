using System.Linq;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Score
    {
        public string Token { get; }
        public int Points { get; private set; }

        public Score(string token)
        {
            Token = token;
            Points = 0;
        }

        public void CalcuteScore(ILobby lobby)
        {
            var player = lobby.Players.SingleOrDefault(entity => entity.Token.Equals(Token));
            var votes = lobby.VoteResults.SingleOrDefault(vote => vote.Id.Equals(player.Card)).Count;
            var canCalculate = true;
            if (Token.Equals(lobby.MainPlayer))
            {
                if (votes.Equals(0))
                {
                    Points -= 2;
                    canCalculate = false;
                }
                if (votes.Equals(lobby.Players.Count-1))
                {
                    Points -= 3;
                    canCalculate = false;
                }
                if (votes < 0 )
                {
                    Points = 0;
                }
            }
            if (canCalculate)
            {
                Points += votes;
            }
           
        }
    }
}
