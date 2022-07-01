namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.Services.Contents.Galleries;
    using Queries.Abstractions;
    using Exceptions;

    public class GalleryCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<GalleryCreateHierarchicRequest>
    {
        private readonly IGalleryService _galleryService;

        public GalleryCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IGalleryService galleryService)
            : base(asyncQueryBuilder)
        {
            _galleryService = galleryService ?? throw new ArgumentNullException(nameof(galleryService));
        }

        protected override async Task<Content> CreateContentAsync(
         string name,
         User user,
         DateTime dateTimeUtc,
         GalleryCreateHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.CoverUrl))
                throw new IncorrectRequestParameters();

            Image cover = new Image(request.CoverUrl);

            var images = new List<Image>();
            foreach (var url in request.ImagesUrls)
            {
                if (string.IsNullOrEmpty(url))
                    throw new IncorrectRequestParameters();
                images.Add(new Image(url));
            }

            Gallery gallery = await _galleryService.CreateGalleryAsync(
                name: name,
                user: user,
                dateTimeUtc: DateTime.UtcNow,
                cover: cover,
                images: images);

            return gallery;
        }
    }
}
