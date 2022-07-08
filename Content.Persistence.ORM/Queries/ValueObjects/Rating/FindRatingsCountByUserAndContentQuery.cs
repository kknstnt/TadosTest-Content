namespace Content.Persistence.ORM.Queries.ValueObjects.Rating
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;
    using Domain.ValueObjects;

    public class FindRatingsCountByUserAndContentQuery :
        LinqAsyncQueryBase<ContentRating, FindRatingsCountByUserAndContent, int>
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
            //var content = await AsyncQuery().SingleAsync(
            //    x => x.Id == criterion.Content.Id, cancellationToken);
            //return content.ContentRatings.Select(cr => cr.User.Id).Contains(criterion.User.Id);

            return AsyncQuery().CountAsync(
                x => x.Content.Id == criterion.Content.Id && x.User.Id == criterion.User.Id,
                cancellationToken);
        }
    }
}