namespace Content.Persistence.ORM.Queries.Entities.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;
    using Exceptions;
    using Domain.Filters;

    public class FindUsersByFilterAndPaginationQuery :
        LinqAsyncQueryBase<User, FindByFilterAndPagination, List<User>>
    {
        public FindUsersByFilterAndPaginationQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<List<User>> AskAsync(
            FindByFilterAndPagination criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<User> query = Query;


            var filter = criterion.Filter as UserGetListFilter;
            var pagination = criterion.Pagination;

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(x => x.Email.Contains(filter.Search));

            if (pagination != null)
            {
                if (pagination.Count < 0 || pagination.Offset < 0)
                    throw new IncorrectFilterParameters();

                query = query
                    .Skip(pagination.Offset)
                    .Take(pagination.Count);
            }

            //query = query.OrderBy(x => x.Email);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}