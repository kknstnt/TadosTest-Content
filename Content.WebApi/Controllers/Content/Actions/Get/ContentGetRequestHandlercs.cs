namespace Content.WebApi.Controllers.Content.Actions.Get
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using AutoMapper;
    using Domain.Criteria;
    using Domain.Entities;
    using Dto;
    using Queries.Abstractions;

    public class ContentGetRequestHandler : IAsyncRequestHandler<ContentGetRequest, ContentGetResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public ContentGetRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContentGetResponse> ExecuteAsync(ContentGetRequest request)
        {
            var content = await _asyncQueryBuilder.FindByIdAsync<Content>(request.Id);

            return new ContentGetResponse(
                Content: _mapper.Map<ContentDto>(content));
        }
    }
}
