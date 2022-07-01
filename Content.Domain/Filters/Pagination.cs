namespace Content.Domain.Filters
{
    public record Pagination
    {
        public int Offset { get; set; }
        
        public int Count { get; set; }
    }
}