namespace Content.WebApi.Controllers.Country.Actions.GetList
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using AutoMapper;
    using Domain.Criteria;
    using Domain.Entities;
    using Dto;
    using Queries.Abstractions;
    using Domain.Filters;
    using System.Linq;

    public class CountryGetListRequestHandler : IAsyncRequestHandler<CountryGetListRequest, CountryGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public CountryGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CountryGetListResponse> ExecuteAsync(CountryGetListRequest request)
        {
            var countries = await _asyncQueryBuilder
                .For<PaginatedList<Country>>()
                .WithAsync(new FindByFilterAndPagination<CountryGetListFilter>(
                    request.Filter,
                    request.Pagination));

            var countriesDto = _mapper.Map<IEnumerable<CountryListItemDto>>(countries.Items);

            return new CountryGetListResponse(
                Page: new PaginatedList<CountryListItemDto>(countries.TotalCount, countriesDto));
        }
    }
}