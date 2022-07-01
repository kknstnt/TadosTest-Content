//namespace Content.Domain.Services.Contents.Videos
//{
//    using System;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using Entities;
//    using global::Commands.Abstractions;
//    using Queries.Abstractions;

//    public class VideoService : ContentServiceBase, IVideoService
//    {
//        public VideoService(IAsyncQueryBuilder asyncQueryBuilder, IAsyncCommandBuilder asyncCommandBuilder)
//           : base(asyncQueryBuilder, asyncCommandBuilder)
//        {
//        }

//        public async Task<Video> CreateVideoAsync(string name, User user, DateTime dateTimeUtc, string uri, CancellationToken cancellationToken = default)
//        {
//            var video = new Video(name, user, dateTimeUtc, uri);

//            await CreateContentAsync(video, cancellationToken);

//            return video;
//        }

//        public void UpdateVideo(Video video, string name, string url)
//        {
//            video.Update(name, url);
//        }
//    }
//}