namespace Content.Domain.Services.Contents
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Contexts;
    using Entities;
    using global::Commands.Abstractions;
    using Queries.Abstractions;

    public abstract class ContentServiceBase
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IAsyncCommandBuilder _asyncCommandBuilder;

        protected ContentServiceBase(IAsyncQueryBuilder asyncQueryBuilder, IAsyncCommandBuilder asyncCommandBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
        }

        protected async Task CreateContentAsync<TContent>(
            TContent content,
            CancellationToken cancellationToken = default)
            where TContent : Content, new()
        {
            await _asyncCommandBuilder.CreateAsync(content, cancellationToken);
        }
    }
}