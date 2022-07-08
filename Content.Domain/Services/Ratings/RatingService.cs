namespace Content.Domain.Services.Ratings
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Criteria;
    using Entities;
    using Exceptions;
    using Queries.Abstractions;

    public class RatingService : IRatingService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public RatingService(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task RateAsync(Content content, User user, int rate, CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (rate < 1 || rate > 5)
                throw new ArgumentException(nameof(rate));

            await CheckIsUserAlreadyRateTheContnetAsync(user, content);

            content.Rate(user, rate);
        }

        private async Task CheckIsUserAlreadyRateTheContnetAsync(User user, Content content, CancellationToken cancellationToken = default)
        {
            int ratingsCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindRatingsCountByUserAndContent(user, content), cancellationToken);

            if (ratingsCount != 0)
                throw new UserAlreadyRatesThisContentException();
        }
    }
}
