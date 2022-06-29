namespace Content.Domain.Services.Ratings
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Domain.Abstractions;

    public interface IRatingService : IDomainService
    {
        Task RateAsync(Content content, User user, int rate, CancellationToken cancellationToken = default);
    }
}
