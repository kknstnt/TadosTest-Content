//namespace Content.Domain.Services.Contents.Articles
//{
//    using System;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using Entities;
//    using global::Commands.Abstractions;
//    using Queries.Abstractions;

//    public class ArticleService : ContentServiceBase, IArticleService
//    {
//        public ArticleService(IAsyncQueryBuilder asyncQueryBuilder, IAsyncCommandBuilder asyncCommandBuilder)
//            : base(asyncQueryBuilder, asyncCommandBuilder)
//        {
//        }
        
//        public async Task<Article> CreateArticleAsync(string name, User user, DateTime dateTimeUtc, string text, CancellationToken cancellationToken = default)
//        {
//            var article = new Article(name, user, dateTimeUtc, text);

//            await CreateContentAsync(article, cancellationToken);

//            return article;
//        }

//        public void UpdateArticle(Article article, string name, string text)
//        {
//            article.Update(name, text);
//        }
//    }
//}