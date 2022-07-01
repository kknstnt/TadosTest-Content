namespace Content.Persistence.ORM.Queries.ValueObjects.Rating
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;
    using System.Linq;

    public class FindRatingsCountByUserAndContentQuery :
        LinqAsyncQueryBase<Content, FindRatingsCountByUserAndContent, int>
    {
        public FindRatingsCountByUserAndContentQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<int> AskAsync(
            FindRatingsCountByUserAndContent criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Id == criterion.Content.Id && x.ContentRatings.Select(y => y.User.Id).Contains(criterion.User.Id),
                cancellationToken);
        }
    }
}