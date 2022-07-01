namespace Content.Domain.Criteria
{
    using Queries.Abstractions;
    using Content.Domain.Filters;

    public record FindByFilterAndPagination(Filter Filter, Pagination Pagination) : ICriterion;
}