namespace Content.Domain.Services.Cities
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Enums;
    using global::Domain.Abstractions;

    public interface IRatingService : IDomainService
    {
        Task<City> CreateCityAsync(string name, Country country, CancellationToken cancellationToken = default);

        Task UpdateCityAsync(City city, string name, Country country, CancellationToken cancellationToken = default);
    }
}
