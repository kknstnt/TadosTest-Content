namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.Services.Contents.Articles;
    using Queries.Abstractions;
    using Exceptions;

    public class ArticleEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<ArticleEditHierarchicRequest>
    {
        private readonly IArticleService _articleService;

        public ArticleEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IArticleService articleService)
            : base(asyncQueryBuilder)
        {
            _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        }

        protected override void UpdateContent(Content content, string name, ArticleEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                throw new IncorrectRequestParameters(); 

            _articleService.UpdateArticle(content as Article, name, request.Text);
        }
    }
}
