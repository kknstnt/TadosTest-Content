namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;
    using Commands.Abstractions;
    using Domain.Commands.Contexts;

    public class VideoCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<VideoCreateHierarchicRequest>
    {

        public VideoCreateHierarchicRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
            : base(queryBuilder, commandBuilder)
        {
        }

        protected override async Task<Content> CreateContentAsync(
         string name,
         User user,
         DateTime dateTimeUtc,
         VideoCreateHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Url))
                throw new IncorrectRequestParameters();

            Video video = new Video(
                name: name,
                user: user,
                dateTimeUtc: DateTime.UtcNow,
                url: request.Url);

            await _commandBuilder.CreateAsync(video);

            return video;
        }
    }
}
