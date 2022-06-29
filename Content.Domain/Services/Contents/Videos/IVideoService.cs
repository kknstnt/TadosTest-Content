﻿namespace Content.Domain.Services.Contents.Videos
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Domain.Abstractions;

    public interface IVideoService : IDomainService
    {
        Task<Video> CreateVideoAsync(
            string name,
            User user,
            DateTime dateTimeUtc,
            string uri,
            CancellationToken cancellationToken = default);
    }
}