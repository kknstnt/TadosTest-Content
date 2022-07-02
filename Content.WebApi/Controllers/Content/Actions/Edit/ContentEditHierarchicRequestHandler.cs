namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Hierarchic.Abstractions;
    using Domain.Criteria;
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;
    using Commands.Abstractions;

    public abstract class ContentEditHierarchicRequestHandler<TConcreteContentHierarchicRequest> :
        AsyncHierarchicRequestHandlerBase<TConcreteContentHierarchicRequest>
            where TConcreteContentHierarchicRequest : ContentEditHierarchicRequest
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        protected readonly IAsyncCommandBuilder _commandBuilder;

        protected ContentEditHierarchicRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder)); ;
        }

        protected override async Task ExecuteAsync(TConcreteContentHierarchicRequest request)
        {
            Content content = await _queryBuilder.FindByIdAsync<Content>(request.Id);
            if (content == null)
                throw new IncorrectRequestParameters();

            await UpdateContentAsync(content, request.Name, request);
        }

        protected abstract Task UpdateContentAsync(
          Content content,
          string name,
          TConcreteContentHierarchicRequest request);
    }
}