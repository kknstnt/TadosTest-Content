namespace Content.Domain.Services.Contents.Galleries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ValueObjects;
    using Entities;
    using global::Domain.Abstractions;

    public interface IGalleryService : IDomainService
    {
        Task<Gallery> CreateGalleryAsync(
            string name,
            User user,
            DateTime dateTimeUtc,
            Image cover,
            CancellationToken cancellationToken = default);
    }
}