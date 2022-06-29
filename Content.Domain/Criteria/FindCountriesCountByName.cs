namespace Content.Domain.Criteria
{
    using Queries.Abstractions;

    public record FindCountriesCountByName(string Name) :  ICriterion;
}