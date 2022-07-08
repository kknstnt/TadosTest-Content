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
        LinqAsyncQueryBase<Country, FindByFilterAndPagination<CountryGetListFilter>, PaginatedList<Country>>
    {
        public FindCountriesByFilterAndPaginationQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override async Task<PaginatedList<Country>> AskAsync(
            FindByFilterAndPagination<CountryGetListFilter> criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Country> query = Query;
            var totalCount = Query.Count();

            var filter = criterion.Filter;
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

            var countries = await ToAsync(query).ToListAsync(cancellationToken);

            return new PaginatedList<Country>(totalCount, countries);
        }
    }
}