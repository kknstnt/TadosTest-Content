namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    [Hierarchy(ContentCategory.Video)]
    public record VideoCreateHierarchicRequest : ContentCreateHierarchicRequest
    {
        public string Url { get; set; }
    }
}