namespace Content.Domain.Services.Users
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Domain.Abstractions;

    public interface IUserService : IDomainService
    {
        Task<User> CreateUserAsync(string login, City city, CancellationToken cancellationToken = default);
    }
}
