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

        public Video(string name, User user, DateTime dateTimeUtc, string url)
            : base(ContentCategory.Video, name, user, dateTimeUtc)
        {
            SetUrl(url);
        }

        public virtual string Url { get; protected set; }

        public virtual void Update(string name, string url)
        {
            SetName(name);
            SetUrl(url);
        }

        protected internal virtual void SetUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));

            Url = url;
        }
    }
}
