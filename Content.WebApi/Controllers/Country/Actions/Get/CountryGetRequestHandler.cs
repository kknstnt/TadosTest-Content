namespace Content.WebApi.Controllers.Country.Actions.Get
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using AutoMapper;
    using Domain.Criteria;
    using Domain.Entities;
    using Dto;
    using Queries.Abstractions;

    public class CountryGetRequestHandler : IAsyncRequestHandler<CountryGetRequest, CountryGetResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public CountryGetRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CountryGetResponse> ExecuteAsync(CountryGetRequest request)
        {
            var country = await _asyncQueryBuilder.FindByIdAsync<Country>(request.Id);

            return new CountryGetResponse(
                Country: _mapper.Map<CountryDto>(country));
        }
    }
}
