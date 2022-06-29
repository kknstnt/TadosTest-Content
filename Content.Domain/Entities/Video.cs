namespace Content.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Enums;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Video : Content
    {
        [Obsolete("Only for reflection", true)]
        public Video()
        {
        }

        protected internal Video(string name, User user, DateTime dateTimeUtc, string uri)
            : base(ContentType.Article, name, user, dateTimeUtc)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentOutOfRangeException(nameof(uri));

            URI = uri;
        }
        public virtual string URI { get; init; }
    }
}
