namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.Services.Contents.Videos;
    using Queries.Abstractions;
    using Exceptions;

    public class VideoCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<VideoCreateHierarchicRequest>
    {
        private readonly IVideoService _videoService;

        public VideoCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IVideoService videoService)
            : base(asyncQueryBuilder)
        {
            _videoService = videoService ?? throw new ArgumentNullException(nameof(videoService));
        }

        protected override async Task<Content> CreateContentAsync(
         string name,
         User user,
         DateTime dateTimeUtc,
         VideoCreateHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Url))
                throw new IncorrectRequestParameters();

            Video video = await _videoService.CreateVideoAsync(
                name: name,
                user: user,
                dateTimeUtc: DateTime.UtcNow,
                url: request.Url);

            return video;
        }
    }
}
