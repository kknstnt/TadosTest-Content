namespace Content.Domain.Services.Contents.Galleries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Commands.Abstractions;
    using Queries.Abstractions;

    public class GalleryService : ContentServiceBase, IGalleryService
    {
        public GalleryService(IAsyncQueryBuilder asyncQueryBuilder, IAsyncCommandBuilder asyncCommandBuilder)
            : base(asyncQueryBuilder, asyncCommandBuilder)
        {
        }

        public async Task<Gallery> CreateGalleryAsync(string name, User user, DateTime dateTimeUtc, Image cover, CancellationToken cancellationToken = default)
        {
            var gallery = new Gallery(name, user, dateTimeUtc, cover);

            await CreateContentAsync(gallery, cancellationToken);

            return gallery;
        }
    }
}