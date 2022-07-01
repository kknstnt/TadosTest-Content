namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.Services.Contents.Galleries;
    using Queries.Abstractions;
    using Exceptions;

    public class GalleryEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<GalleryEditHierarchicRequest>
    {
        private readonly IGalleryService _galleryService;

        public GalleryEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IGalleryService galleryService)
            : base(asyncQueryBuilder)
        {
            _galleryService = galleryService ?? throw new ArgumentNullException(nameof(galleryService));
        }

        protected override void UpdateContent(Content content, string name, GalleryEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.CoverUrl))
                throw new IncorrectRequestParameters();
            var coverImage = new Image(request.CoverUrl);

            var images = new List<Image>();
            foreach (var url in request.ImagesUrls)
            {
                if (string.IsNullOrWhiteSpace(url))
                    throw new IncorrectRequestParameters();
                images.Add(new Image(url));
            }

            _galleryService.UpdateGallery(content as Gallery, name, coverImage, images);
        }
    }
}
