namespace Content.Persistence.ORM.Queries.Entities.Country
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

    public class FindCountriesByFilterAndPaginationQuery :
        LinqAsyncQueryBase<Country, FindByFilterAndPagination, List<Country>>
    {
        public FindCountriesByFilterAndPaginationQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<List<Country>> AskAsync(
            FindByFilterAndPagination criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Country> query = Query;

            var filter = criterion.Filter as CountryGetListFilter;
            var pagination = criterion.Pagination;

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(x => x.Name.Contains(filter.Search));

            if (pagination != null)
            {
                if (pagination.Count < 0 || pagination.Offset < 0)
                    throw new IncorrectFilterParameters();

                query = query
                    .Skip(pagination.Offset)
                    .Take(pagination.Count);
            }

            //query = query.OrderBy(x => x.Name);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}