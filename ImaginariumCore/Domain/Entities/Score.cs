namespace Domain.Entities
{
    public class Score
    {
        public string Token { get; set; }
        public int Points { get; set; }

        public Score(string token)
        {
            Token = token;
            Points = 0;
        }
    }
}
