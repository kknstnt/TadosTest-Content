namespace Content.WebApi.Controllers.City.Actions.Edit
{
    using System;
    using System.Threading.Tasks;
    using Domain.Services.Cities;
    using global::Content.Domain.Criteria;
    using Queries.Abstractions;
    using Domain.Entities;
    using Api.Requests.Abstractions;
    using Exceptions;

    public class CityEditRequestHandler : IAsyncRequestHandler<CityEditRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IRatingService _cityService;

        public CityEditRequestHandler(IRatingService cityService, IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }

        public async Task ExecuteAsync(CityEditRequest request)
        {
            var city = await _queryBuilder.FindByIdAsync<City>(request.Id);
            var country = await _queryBuilder.FindByIdAsync<Country>(request.CountryId);

            if (country == null || city == null)
                throw new IncorrectRequestParameters();

            if (city.Name == request.Name && city.Country.Id == request.CountryId)
                return;

            await _cityService.UpdateCityAsync(city, request.Name, country);
        }
    }
}
