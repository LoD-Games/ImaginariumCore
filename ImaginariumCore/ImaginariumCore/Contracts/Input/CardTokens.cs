using System;
using System.Net.Http;

namespace ImaginariumCore.Contracts.Input
{
    public class CardTokens
    {
        public int Card { get; set; }
        public Tokens Tokens { get; set; }

        public CardTokens(int card, Tokens tokens)
        {
            if (card < 1 || card > 96 )
            {
                throw new HttpRequestException("invalid arugments", new ArgumentException());
            }
            Card = card;
            Tokens = tokens;
        }
    }
}
