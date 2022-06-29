namespace Content.Domain.Criteria
{
    using Queries.Abstractions;

    public record FindUsersCountByLogin(string Login) : ICriterion;
}