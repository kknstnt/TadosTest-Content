namespace Content.Domain.Criteria
{
    using System.Threading;
    using System.Threading.Tasks;
    using global::Domain.Abstractions;
    using Queries.Abstractions;
    public class FindById : ICriterion
    {
        public FindById(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
