namespace Content.Domain.Services.Cities
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Contexts;
    using Criteria;
    using Entities;
    using Exceptions;
    using global::Commands.Abstractions;
    using Queries.Abstractions;

    public class CityService : IRatingService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;

        public CityService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task UpdateCityAsync(City city, string name, Country country, CancellationToken cancellationToken = default)
        {
            await CheckIsCityWithSameNameExistAsync(name, country, cancellationToken);

            city.Update(name, country);
        }

        public async Task<City> CreateCityAsync(string name, Country country, CancellationToken cancellationToken = default)
        {
            await CheckIsCityWithSameNameExistAsync(name, country, cancellationToken);

            var city = new City(name, country);

            await _commandBuilder.CreateAsync(city, cancellationToken);

            return city;
        }


        private async Task CheckIsCityWithSameNameExistAsync(string name, Country country, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindCitiesCountByNameAndCountry(name, country), cancellationToken);

            if (existingCount != 0)
                throw new NameAlreadyExistsException();
        }
    }
}
