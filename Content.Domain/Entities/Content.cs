namespace Content.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using global::Domain.Abstractions;
    using Enums;
    using ValueObjects;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Content : IEntity
    {
        private readonly ICollection<ContentRating> _contentRatings = new HashSet<ContentRating>();

        [Obsolete("Only for reflection", true)]
        public Content()
        {
        }

        public Content(ContentCategory type, string name, User user, DateTime dateTimeUtc)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            SetName(name);
            Category = type;
            Creator = user;
            DateTimeUtc = dateTimeUtc;
        }

        public virtual long Id { get; init; }

        public virtual string Name { get; protected set; }

        public virtual User Creator { get; init; }

        public virtual DateTime DateTimeUtc { get; init; }

        public virtual ContentCategory Category { get; init; }

        public virtual IEnumerable<ContentRating> ContentRatings => _contentRatings;

        protected internal virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        protected internal virtual void Rate(User user, int rate)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (rate < 1 || rate > 5)
                throw new ArgumentException("Value must be between 1 and 5.", nameof(rate));

            ContentRating rating = new ContentRating(DateTime.UtcNow, rate, user);
            _contentRatings.Add(rating);
        }
    }
}
