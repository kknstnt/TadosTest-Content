namespace Content.Domain.Criteria
{
    using Entities;
    using Queries.Abstractions;

    public record FindRatingsCountByUserAndContent(User User, Content Content) : ICriterion;
}