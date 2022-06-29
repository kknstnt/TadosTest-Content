namespace Content.Domain.Criteria
{
    using Entities;
    using Queries.Abstractions;

    public record FindCitiesCountByNameAndCountry(string Name, Country Country) : ICriterion;
}