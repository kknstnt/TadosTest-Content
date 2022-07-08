namespace Content.Domain.Filters
{
    using System.Collections.Generic;
    using System.Linq;

    public class PaginatedList<T>
    {
        public PaginatedList(int totalCount, IEnumerable<T> items)
        {
            TotalCount = totalCount;
            Items = items.ToList();
        }

        public int TotalCount { get; init; }

        public List<T> Items { get; init; }
    }
}