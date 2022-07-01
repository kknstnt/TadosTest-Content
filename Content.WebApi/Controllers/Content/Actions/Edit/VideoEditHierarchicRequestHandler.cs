namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System;
    using Domain.Entities;
    using Domain.Services.Contents.Videos;
    using Queries.Abstractions;
    using Exceptions;

    public class VideoEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<VideoEditHierarchicRequest>
    {
        private readonly IVideoService _videoService;

        public VideoEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IVideoService videoService)
            : base(asyncQueryBuilder)
        {
            _videoService = videoService ?? throw new ArgumentNullException(nameof(videoService));
        }

        protected override void UpdateContent(Content content, string name, VideoEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Url))
                throw new IncorrectRequestParameters();

            _videoService.UpdateVideo(content as Video, name, request.Url);
        }
    }
}
