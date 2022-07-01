namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Domain.Entities;
    using Queries.Abstractions;
    using Exceptions;

    public class VideoEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<VideoEditHierarchicRequest>
    {
        public VideoEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
            : base(asyncQueryBuilder)
        {
        }

        protected override void UpdateContent(Content content, string name, VideoEditHierarchicRequest request)
        {
            if (string.IsNullOrEmpty(request.Url))
                throw new IncorrectRequestParameters();

            (content as Video).Update(name, request.Url);
        }
    }
}
