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

        protected internal ContentRating(DateTime dateTimeUtc, int rate, User user, Content content)
        {
            SetRate(rate);
            SetUser(user);
            SetContent(content);
            DateTimeUtc = dateTimeUtc;
        }

        public virtual long Id { get; init; }

        public virtual DateTime DateTimeUtc { get; init; }

        public virtual int Rate { get; protected set; }

        public virtual User User { get; protected set; }

        public virtual Content Content { get; protected set; }

        protected internal virtual void SetRate(int rate)
        {
            Rate = rate;
        }

        protected internal virtual void SetUser(User user)
        {
            User = user;
        }

        protected internal virtual void SetContent(Content content)
        {
            Content = content;
        }
    }
}
