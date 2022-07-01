//namespace Content.Domain.Services.Contents.Galleries
//{
//    using System;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using System.Collections.Generic;
//    using Entities;
//    using global::Domain.Abstractions;

//    public interface IGalleryService : IDomainService
//    {
//        Task<Gallery> CreateGalleryAsync(
//            string name,
//            User user,
//            DateTime dateTimeUtc,
//            Image cover,
//            IEnumerable<Image> images,
//            CancellationToken cancellationToken = default);

//        void UpdateGallery(
//            Gallery gallery,
//            string name,
//            Image cover,
//            IEnumerable<Image> imagesUrls);
//    }
//}