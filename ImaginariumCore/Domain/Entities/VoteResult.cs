namespace Domain.Entities
{
    public class VoteResult
    {
        public int Id { get; }
        public int Count { get; }

        public VoteResult(int id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
