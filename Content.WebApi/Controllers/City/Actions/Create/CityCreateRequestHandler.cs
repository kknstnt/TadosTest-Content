namespace Content.WebApi.Controllers.City.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using Domain.Entities;
    using Domain.Services.Cities;
    using global::Content.Domain.Criteria;
    using Queries.Abstractions;
    using Exceptions;

    public class CityCreateRequestHandler : IAsyncRequestHandler<CityCreateRequest, CityCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IRatingService _cityService;

        public CityCreateRequestHandler(IRatingService countryService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _cityService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        public async Task<CityCreateResponse> ExecuteAsync(CityCreateRequest request)
        {
            Country country = await _asyncQueryBuilder.FindByIdAsync<Country>(request.CountryId);

            if (country == null)
                throw new IncorrectRequestParameters();

            City city = await _cityService.CreateCityAsync(
                name: request.Name.Trim(),
                country: country
            );

            return new CityCreateResponse(
                Id: city.Id);
        }
    }
}
