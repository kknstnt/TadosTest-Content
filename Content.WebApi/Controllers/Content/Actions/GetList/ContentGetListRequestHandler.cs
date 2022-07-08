namespace Content.WebApi.Controllers.Content.Actions.GetList
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

    public class ContentGetListRequestHandler : IAsyncRequestHandler<ContentGetListRequest, ContentGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public ContentGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContentGetListResponse> ExecuteAsync(ContentGetListRequest request)
        {
            var contents = await _asyncQueryBuilder
                .For<PaginatedList<Content>>()
                .WithAsync(new FindByFilterAndPagination<ContentGetListFilter>(
                    request.Filter,
                    request.Pagination));

            var contentsDto = _mapper.Map<IEnumerable<ContentListItemDto>>(contents.Items);

            return new ContentGetListResponse(
                Page: new PaginatedList<ContentListItemDto>(contents.TotalCount, contentsDto));
        }
    }
}
