namespace Content.Domain.Services.Users
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Domain.Abstractions;

    public interface IUserService : IDomainService
    {
        Task<User> CreateUserAsync(string email, City city, CancellationToken cancellationToken = default);

        Task UpdateUserAsync(User user, string email, City city, CancellationToken cancellationToken = default);
    }
}
