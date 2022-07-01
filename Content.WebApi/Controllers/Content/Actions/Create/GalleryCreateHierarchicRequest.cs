namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System.Collections.Generic;
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    [Hierarchy(ContentCategory.Gallery)]
    public record GalleryCreateHierarchicRequest : ContentCreateHierarchicRequest
    {
        public string CoverUrl { get; init; }

        public List<string> ImagesUrls { get; init; }
    }
}