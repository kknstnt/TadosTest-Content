namespace Content.Domain.Criteria
{
    using Queries.Abstractions;

    public record FindUsersCountByEmail(string Email) : ICriterion;
}