namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Domain.Entities;
    using Domain.ValueObjects;
    using Queries.Abstractions;
    using Exceptions;
    using Commands.Abstractions;
    using Domain.Commands.Contexts;
    using System.Threading.Tasks;

    public class GalleryEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<GalleryEditHierarchicRequest>
    {
        public GalleryEditHierarchicRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
            : base(queryBuilder, commandBuilder)
        {
        }

        protected override async Task UpdateContentAsync(Content content, string name, GalleryEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.CoverUrl) || request.ImagesUrls == null)
                throw new IncorrectRequestParameters();

            var gallery = content as Gallery;
            gallery.Update(name, request.CoverUrl, request.ImagesUrls);

            await _commandBuilder.UpdateAsync(gallery);
        }
    }
}
