namespace Content.Domain.Filters
{
    public record Pagination
    {
        public int Offset { get; init; }
        
        public int Count { get; init; }
    }
}