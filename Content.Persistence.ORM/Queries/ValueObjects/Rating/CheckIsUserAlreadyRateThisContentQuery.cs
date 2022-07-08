namespace Content.Persistence.ORM.Queries.ValueObjects.Rating
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;
    using System.Linq;

    public class CheckIsUserAlreadyRateThisContentQuery :
        LinqAsyncQueryBase<Content, CheckIsUserAlreadyRateThisContent, bool>
    {
        public CheckIsUserAlreadyRateThisContentQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override async Task<bool> AskAsync(
            CheckIsUserAlreadyRateThisContent criterion,
            CancellationToken cancellationToken = default)
        {
            var content = await AsyncQuery().SingleAsync(
                x => x.Id == criterion.Content.Id, cancellationToken);
            return content.ContentRatings.Select(cr => cr.User.Id).Contains(criterion.User.Id);
        }
    }
}