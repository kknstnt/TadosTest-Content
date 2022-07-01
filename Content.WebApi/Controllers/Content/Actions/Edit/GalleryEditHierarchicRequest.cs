namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System.Collections.Generic;

    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    [Hierarchy(ContentCategory.Gallery)]
    public record GalleryEditHierarchicRequest : ContentEditHierarchicRequest
    {
        public string CoverUrl { get; set; }

        public List<string> ImagesUrls { get; set; }
    }
}