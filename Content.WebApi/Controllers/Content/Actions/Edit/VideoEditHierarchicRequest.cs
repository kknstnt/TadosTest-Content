namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    [Hierarchy(ContentCategory.Video)]
    public record VideoEditHierarchicRequest : ContentEditHierarchicRequest
    {
        public string Url { get; set; }
    }
}