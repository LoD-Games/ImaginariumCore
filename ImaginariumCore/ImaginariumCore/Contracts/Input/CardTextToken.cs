namespace ImaginariumCore.Contracts.Input
{
    public class CardTextToken
    {
        public int Card { get; set; }
        public string Text { get; set; }
        public Tokens PlayerToken { get; set; }

        public CardTextToken(int card, string text, Tokens playerToken)
        {
            if (card < 1 || card > 96 || text.Equals(string.Empty))
            {
                
            }
            Card = card;
            Text = text;
            PlayerToken = playerToken;
        }
    }
}
