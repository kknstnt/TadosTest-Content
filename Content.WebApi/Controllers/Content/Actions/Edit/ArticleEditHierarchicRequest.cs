namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    [Hierarchy(ContentCategory.Article)]
    public record ArticleEditHierarchicRequest : ContentEditHierarchicRequest
    {
        public string Text { get; set; }
    }
}