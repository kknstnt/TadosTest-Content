namespace Content.Domain.Services.Contents.Galleries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Commands.Abstractions;
    using Queries.Abstractions;
    using System.Collections.Generic;

    public class GalleryService : ContentServiceBase, IGalleryService
    {
        public GalleryService(IAsyncQueryBuilder asyncQueryBuilder, IAsyncCommandBuilder asyncCommandBuilder)
            : base(asyncQueryBuilder, asyncCommandBuilder)
        {
        }

        public async Task<Gallery> CreateGalleryAsync(string name, User user, DateTime dateTimeUtc, Image cover, IEnumerable<Image> images, CancellationToken cancellationToken = default)
        {
            var gallery = new Gallery(name, user, dateTimeUtc, cover, images);

            await CreateContentAsync(gallery, cancellationToken);

            return gallery;
        }

        public void UpdateGallery(Gallery gallery, string name, Image cover, IEnumerable<Image> images)
        {
            gallery.Update(name, cover, images);
        }
    }
}