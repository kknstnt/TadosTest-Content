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

        protected internal Video(string name, User user, DateTime dateTimeUtc, string url)
            : base(ContentType.Video, name, user, dateTimeUtc)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));

            Url = url;
        }
        public virtual string Url { get; init; }
    }
}
