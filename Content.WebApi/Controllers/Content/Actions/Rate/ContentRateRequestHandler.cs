namespace Content.WebApi.Controllers.Content.Actions.Rate
{
    using System;
    using System.Threading.Tasks;
    using Domain.Services.Ratings;
    using global::Content.Domain.Criteria;
    using Queries.Abstractions;
    using Domain.Entities;
    using Api.Requests.Abstractions;

    public class ContentRateRequestHandler : IAsyncRequestHandler<ContentRateRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IRatingService _ratingService;

        public ContentRateRequestHandler(IRatingService ratingService, IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _ratingService = ratingService ?? throw new ArgumentNullException(nameof(ratingService));
        }

        public async Task ExecuteAsync(ContentRateRequest request)
        {
            var user = await _queryBuilder.FindByIdAsync<User>(request.UserId);
            var content = await _queryBuilder.FindByIdAsync<Content>(request.ContentId);

            await _ratingService.RateAsync(content, user, request.Rate);
        }
    }
}
