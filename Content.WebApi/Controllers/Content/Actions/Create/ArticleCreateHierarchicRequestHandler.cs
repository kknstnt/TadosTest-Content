namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.Services.Contents.Articles;
    using Queries.Abstractions;
    using Exceptions;

    public class ArticleCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<ArticleCreateHierarchicRequest>
    {
        private readonly IArticleService _articleService;

        public ArticleCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IArticleService articleService)
            : base(asyncQueryBuilder)
        {
            _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        }

        protected override async Task<Content> CreateContentAsync(
         string name,
         User user,
         DateTime dateTimeUtc,
         ArticleCreateHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                throw new IncorrectRequestParameters();

            Article article = await _articleService.CreateArticleAsync(
                name: name,
                user: user,
                dateTimeUtc: DateTime.UtcNow,
                text: request.Text);

            return article;
        }
    }
}
