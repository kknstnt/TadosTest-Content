﻿namespace Content.Persistence.ORM.Queries.Entities.City
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

    public class FindCitiesByFilterAndPaginationQuery :
        LinqAsyncQueryBase<City, FindByFilterAndPagination, List<City>>
    {
        public FindCitiesByFilterAndPaginationQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<List<City>> AskAsync(
            FindByFilterAndPagination criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<City> query = Query;

            var filter = criterion.Filter as CityGetListFilter;
            var pagination = criterion.Pagination;

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(x => x.Name.Contains(filter.Search));

            if (filter.CountryId.HasValue)
                query = query.Where(x => x.Country.Id == filter.CountryId);

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