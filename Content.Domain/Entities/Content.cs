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
            SetName(name);
            SetCreator(user);
            Category = type;
            DateTimeUtc = dateTimeUtc;
        }

        public virtual long Id { get; init; }

        public virtual string Name { get; protected set; }

        public virtual User Creator { get; protected set; }

        public virtual DateTime DateTimeUtc { get; init; }

        public virtual ContentCategory Category { get; init; }

        public virtual IEnumerable<ContentRating> ContentRatings => _contentRatings;

        protected internal virtual void Rate(User user, int rate)
        {
            ContentRating rating = new ContentRating(DateTime.UtcNow, rate, user);
            _contentRatings.Add(rating);
        }

        protected internal virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        protected internal virtual void SetCreator(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            Creator = user;
        }
    }
}
