namespace Content.Persistence.ORM.Queries.Entities.Content
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

    public class FindContentsByFilterAndPaginationQuery :
        LinqAsyncQueryBase<Content, FindByFilterAndPagination<ContentGetListFilter>, PaginatedList<Content>>
    {
        public FindContentsByFilterAndPaginationQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override async Task<PaginatedList<Content>> AskAsync(
            FindByFilterAndPagination<ContentGetListFilter> criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Content> query = Query;
            var totalCount = query.Count();

            var filter = criterion.Filter;
            var pagination = criterion.Pagination;

            if (filter.Category.HasValue)
                query = query.Where(x => x.Category == filter.Category.Value);

            if (filter.UserId.HasValue)
                query = query.Where(x => x.Creator.Id == filter.UserId);

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(x => x.Name.Contains(filter.Search) 
                || (x as Article) != null && (x as Article).Text.Contains(filter.Search)
                || (x as Video) != null && (x as Video).Url.Contains(filter.Search)
                || (x as Gallery) != null && (x as Gallery).CoverUrl.Contains(filter.Search));

            if (pagination != null)
            {
                if (pagination.Count < 0 || pagination.Offset < 0)
                    throw new IncorrectFilterParameters();

                query = query
                    .Skip(pagination.Offset)
                    .Take(pagination.Count);
            }

            var contents = await ToAsync(query).ToListAsync(cancellationToken);
            return new PaginatedList<Content>(totalCount, contents);
        }
    }
}