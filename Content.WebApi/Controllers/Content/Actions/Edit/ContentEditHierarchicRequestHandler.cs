namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Hierarchic.Abstractions;
    using Domain.Criteria;
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;

    public abstract class ContentEditHierarchicRequestHandler<TConcreteContentHierarchicRequest> :
        AsyncHierarchicRequestHandlerBase<TConcreteContentHierarchicRequest>
            where TConcreteContentHierarchicRequest : ContentEditHierarchicRequest
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;

        protected ContentEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }

        protected override async Task ExecuteAsync(TConcreteContentHierarchicRequest request)
        {
            Content content = await _asyncQueryBuilder.FindByIdAsync<Content>(request.Id);
            if (content == null)
                throw new IncorrectRequestParameters();

            UpdateContent(content, request.Name, request);
        }

        protected abstract void UpdateContent(
          Content content,
          string name,
          TConcreteContentHierarchicRequest request);
    }
}