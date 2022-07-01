namespace Content.Persistence.ORM.Queries.Entities.City
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;

    public class FindUsersCountByEmailQuery :
        LinqAsyncQueryBase<User, FindUsersCountByEmail, int>
    {
        public FindUsersCountByEmailQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<int> AskAsync(
            FindUsersCountByEmail criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Email == criterion.Email,
                cancellationToken);
        }
    }
}