namespace Domain.Entities
{
    public class Player
    {
        public string Token { get; }

        public Player(string token)
        {
            Token = token;
        }
    }
}
