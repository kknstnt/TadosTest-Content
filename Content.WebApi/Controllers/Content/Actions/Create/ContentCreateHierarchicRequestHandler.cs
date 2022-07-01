namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Hierarchic.Abstractions;
    using Domain.Criteria;
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;

    public abstract class ContentCreateHierarchicRequestHandler<TConcreteContentHierarchicRequest> : 
        AsyncHierarchicRequestHandlerBase<TConcreteContentHierarchicRequest, 
        ContentCreateHierarchicResponse>
            where TConcreteContentHierarchicRequest : ContentCreateHierarchicRequest
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;

        protected ContentCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }

        protected override async Task<ContentCreateHierarchicResponse> ExecuteAsync(TConcreteContentHierarchicRequest request)
        {
            var user = await _asyncQueryBuilder.FindByIdAsync<User>(request.UserId);
            if (user == null)
                throw new IncorrectRequestParameters();

            Content content = await CreateContentAsync(
                name: request.Name.Trim(),
                user: user,
                dateTimeUtc: DateTime.UtcNow,
                request: request);

            return new ContentCreateHierarchicResponse(
                Id: content.Id);
        }

        protected abstract Task<Content> CreateContentAsync(
          string name,
          User user,
          DateTime dateTimeUtc,
          TConcreteContentHierarchicRequest request);
    }
}
