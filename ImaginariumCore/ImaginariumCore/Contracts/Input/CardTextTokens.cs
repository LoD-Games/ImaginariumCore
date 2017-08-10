using System;
using System.Net.Http;

namespace ImaginariumCore.Contracts.Input
{
    public class CardTextTokens
    {
        public int Card { get; set; }
        public string Text { get; set; }
        public Tokens Tokens { get; set; }

        public CardTextTokens(int card, string text, Tokens tokens)
        {
            if (card < 1 || card > 96 || text.Equals(string.Empty))
            {
                throw new HttpRequestException("invalid arugments",new ArgumentException());
            }
            Card = card;
            Text = text;
            Tokens = tokens;
        }
    }
}
