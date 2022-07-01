namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.ValueObjects;
    using Queries.Abstractions;
    using Exceptions;

    public class GalleryEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<GalleryEditHierarchicRequest>
    {
        public GalleryEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
            : base(asyncQueryBuilder)
        {
        }

        protected override void UpdateContent(Content content, string name, GalleryEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.CoverUrl) || request.ImagesUrls == null)
                throw new IncorrectRequestParameters();
            var coverImage = new Image(request.CoverUrl);

            (content as Gallery).Update(name, coverImage, request.ImagesUrls);
        }
    }
}
