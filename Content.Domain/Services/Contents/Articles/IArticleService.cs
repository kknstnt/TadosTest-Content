//namespace Content.Domain.Services.Contents.Articles
//{
//    using System;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using Entities;
//    using global::Domain.Abstractions;

//    public interface IArticleService : IDomainService
//    {
//        Task<Article> CreateArticleAsync(
//            string name,
//            User user,
//            DateTime dateTimeUtc,
//            string text,
//            CancellationToken cancellationToken = default);

//       void UpdateArticle(
//            Article article,
//            string name,
//            string text);
//    }
//}