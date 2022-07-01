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
        LinqAsyncQueryBase<Content, FindRatingsCountByUserAndContent, bool>
    {
        public FindRatingsCountByUserAndContentQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<bool> AskAsync(
            FindRatingsCountByUserAndContent criterion,
            CancellationToken cancellationToken = default)
        {
            var content = AsyncQuery().SingleAsync(
                x => x.Id == criterion.Content.Id, cancellationToken);
            return Task.FromResult(content.Result.ContentRatings.Select(cr => cr.User.Id).Contains(criterion.User.Id));

            //return AsyncQuery().CountAsync(
            //    x => x.Id == criterion.Content.Id && x.ContentRatings.Select(y => y.User.Id).Contains(criterion.User.Id),
            //    cancellationToken);
        }
    }
}