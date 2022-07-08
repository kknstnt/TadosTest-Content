namespace Content.Domain.Criteria
{
    using Queries.Abstractions;
    using Content.Domain.Filters;

    public record FindByFilterAndPagination<TFilter>(TFilter Filter, Pagination Pagination) : ICriterion
        where TFilter : IFilter;
}