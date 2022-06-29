namespace Content.WebApi.Controllers.Country.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using Domain.Entities;
    using Domain.Services.Countries;

    public class CountryCreateRequestHandler : IAsyncRequestHandler<CountryCreateRequest, CountryCreateResponse>
    {
        private readonly ICountryService _countryService;

        public CountryCreateRequestHandler(ICountryService countryService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        public async Task<CountryCreateResponse> ExecuteAsync(CountryCreateRequest request)
        {
            Country country = await _countryService.CreateCountryAsync(
                name: request.Name.Trim()
            );

            return new CountryCreateResponse(
                Id: country.Id);
        }
    }
}
