namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    [Hierarchy(ContentCategory.Article)]
    public record ArticleCreateHierarchicRequest : ContentCreateHierarchicRequest
    {
        public string Text { get; init; }
    }
}