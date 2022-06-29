namespace Content.Domain.Criteria
{
    using Enums;
    using Queries.Abstractions;

    public record FindBySearchAndName(string Search, string Name) : ICriterion;
}