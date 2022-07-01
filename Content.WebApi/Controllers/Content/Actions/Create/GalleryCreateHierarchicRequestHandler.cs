namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.ValueObjects;
    using Queries.Abstractions;
    using Exceptions;
    using Commands.Abstractions;
    using Domain.Commands.Contexts;
    using System.Threading.Tasks;

    public class GalleryCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<GalleryCreateHierarchicRequest>
    {
        public GalleryCreateHierarchicRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
            : base(queryBuilder, commandBuilder)
        {
        }

        protected override async Task<Content> CreateContentAsync(
         string name,
         User user,
         DateTime dateTimeUtc,
         GalleryCreateHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.CoverUrl) || request.ImagesUrls == null)
                throw new IncorrectRequestParameters();

            Image cover = new Image(request.CoverUrl);

            Gallery gallery = new Gallery(
                name: name,
                user: user,
                dateTimeUtc: DateTime.UtcNow,
                cover: cover);

            await _commandBuilder.CreateAsync(gallery);

            foreach (var url in request.ImagesUrls)
            {
                if (string.IsNullOrEmpty(url))
                    throw new IncorrectRequestParameters();
                gallery.AddImage(url);
            }

            return gallery;
        }
    }
}
