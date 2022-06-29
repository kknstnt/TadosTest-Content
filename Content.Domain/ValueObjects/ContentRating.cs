namespace Content.Domain.ValueObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::Domain.Abstractions;
    using Entities;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class ContentRating : IValueObjectWithId
    {
        [Obsolete("Only for reflection", true)]
        public ContentRating()
        {
        }

        protected internal ContentRating(DateTime dateTimeUtc, int rate, User user)
        {
            if (rate < 1 || rate > 5)
                throw new ArgumentException("Value must be between 1 and 5.", nameof(rate));

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            DateTimeUtc = dateTimeUtc;
            Rate = rate;
            User = user;
        }

        public virtual long Id { get; init; }

        public virtual DateTime DateTimeUtc { get; init; }

        public virtual int Rate { get; init; }

        public virtual User User { get; init; }
    }
}
