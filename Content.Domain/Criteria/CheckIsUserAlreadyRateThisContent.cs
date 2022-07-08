namespace Content.Domain.Criteria
{
    using Entities;
    using Queries.Abstractions;

    public record CheckIsUserAlreadyRateThisContent(User User, Content Content) : ICriterion;
}