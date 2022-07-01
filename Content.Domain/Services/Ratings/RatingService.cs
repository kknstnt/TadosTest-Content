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
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;

        public RatingService(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }

        public async Task RateAsync(Content content, User user, int rate, CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (rate < 0 || rate > 5)
                throw new ArgumentNullException(nameof(rate));

            await CheckIsUserAlreadyRateTheContnetAsync(user, content);

            content.Rate(user, rate);
        }

        private async Task CheckIsUserAlreadyRateTheContnetAsync(User user, Content content, CancellationToken cancellationToken = default)
        {
            bool isAlreadeRate = await _asyncQueryBuilder
                .For<bool>()
                .WithAsync(new FindRatingsCountByUserAndContent(user, content), cancellationToken);

            if (isAlreadeRate)
                throw new UserAlreadyRatesThisContentException();
        }
    }
}
