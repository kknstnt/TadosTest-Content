namespace Content.WebApi.Controllers.City.Actions.GetList
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

    public class CityGetListRequestHandler : IAsyncRequestHandler<CityGetListRequest, CityGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public CityGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CityGetListResponse> ExecuteAsync(CityGetListRequest request)
        {
            var cities = await _asyncQueryBuilder
                .For<PaginatedList<City>>()
                .WithAsync(new FindByFilterAndPagination<CityGetListFilter>(
                    request.Filter,
                    request.Pagination));

            var citiesDto = _mapper.Map<IEnumerable<CityListItemDto>>(cities.Items);

            return new CityGetListResponse(
                Page: new PaginatedList<CityListItemDto>(cities.TotalCount, citiesDto));
        }
    }
}
