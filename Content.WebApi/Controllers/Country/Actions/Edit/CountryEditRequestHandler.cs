namespace Content.WebApi.Controllers.Country.Actions.Edit
{
    using System;
    using System.Threading.Tasks;
    using Domain.Services.Countries;
    using global::Content.Domain.Criteria;
    using Queries.Abstractions;
    using Domain.Entities;
    using Api.Requests.Abstractions;
    using Exceptions;

    public class CountryEditRequestHandler : IAsyncRequestHandler<CountryEditRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly ICountryService _countryService;

        public CountryEditRequestHandler(ICountryService countryService, IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        public async Task ExecuteAsync(CountryEditRequest request)
        {
            var country = await _queryBuilder.FindByIdAsync<Country>(request.Id);
            if (country == null)
                throw new IncorrectRequestParameters();

            if (country.Name == request.Name)
                return;

            await _countryService.UpdateCountryAsync(country, request.Name);
        }
    }
}
