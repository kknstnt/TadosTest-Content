namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;
    using Commands.Abstractions;
    using Domain.Commands.Contexts;

    public class ArticleCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<ArticleCreateHierarchicRequest>
    {
        public ArticleCreateHierarchicRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
            : base(queryBuilder, commandBuilder)
        {
        }

        protected override async Task<Content> CreateContentAsync(
         string name,
         User user,
         DateTime dateTimeUtc,
         ArticleCreateHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                throw new IncorrectRequestParameters();

            Article article = new Article(
                name: name,
                user: user,
                dateTimeUtc: DateTime.UtcNow,
                text: request.Text);

            await _commandBuilder.CreateAsync(article);

            return article;
        }
    }
}
