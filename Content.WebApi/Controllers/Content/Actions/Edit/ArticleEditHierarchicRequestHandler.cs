namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;
    using Commands.Abstractions;
    using Domain.Commands.Contexts;
    using System.Threading.Tasks;

    public class ArticleEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<ArticleEditHierarchicRequest>
    {
        public ArticleEditHierarchicRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
            : base(queryBuilder, commandBuilder)
        {
        }

        protected override async Task UpdateContentAsync(Content content, string name, ArticleEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                throw new IncorrectRequestParameters();

            var article = content as Article;
            article.Update(name, request.Text);

            await _commandBuilder.UpdateAsync(article);
        }
    }
}
