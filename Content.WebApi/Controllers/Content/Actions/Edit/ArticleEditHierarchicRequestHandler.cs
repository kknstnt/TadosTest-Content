namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;

    public class ArticleEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<ArticleEditHierarchicRequest>
    {
        public ArticleEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
            : base(asyncQueryBuilder)
        {
        }

        protected override void UpdateContent(Content content, string name, ArticleEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                throw new IncorrectRequestParameters();

            (content as Article).Update(name, request.Text);
        }
    }
}
