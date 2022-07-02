namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;
    using Commands.Abstractions;
    using Domain.Commands.Contexts;
    using System.Threading.Tasks;

    public class VideoEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<VideoEditHierarchicRequest>
    {
        public VideoEditHierarchicRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
            : base(queryBuilder, commandBuilder)
        {
        }

        protected override async Task UpdateContentAsync(Content content, string name, VideoEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Url))
                throw new IncorrectRequestParameters();

            var video = content as Video;
            video.Update(name, request.Url);

            await _commandBuilder.UpdateAsync(video);
        }
    }
}
