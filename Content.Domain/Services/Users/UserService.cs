namespace Content.Domain.Services.Users
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Contexts;
    using Criteria;
    using Entities;
    using Enums;
    using Exceptions;
    using global::Commands.Abstractions;
    using Queries.Abstractions;

    public class UserService : IUserService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;

        public UserService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task UpdateUserAsync(User user, string email, City city, CancellationToken cancellationToken = default)
        {
            await CheckIsUserWithSameLoginExistAsync(email, cancellationToken);

            user.Update(email, city);
        }

        public async Task<User> CreateUserAsync(string email, City city, CancellationToken cancellationToken = default)
        {
            await CheckIsUserWithSameLoginExistAsync(email, cancellationToken);

            var user = new User(email, city);

            await _commandBuilder.CreateAsync(user, cancellationToken);

            return user;
        }

        private async Task CheckIsUserWithSameLoginExistAsync(string login, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindUsersCountByEmail(login), cancellationToken);

            if (existingCount != 0)
                throw new NameAlreadyExistsException();
        }
    }
}
