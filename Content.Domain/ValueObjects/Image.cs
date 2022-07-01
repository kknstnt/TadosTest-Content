namespace Content.Domain.ValueObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::Domain.Abstractions;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Image : IValueObjectWithId
    {
        [Obsolete("Only for reflection", true)]
        public Image()
        {
        }

        public Image(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));

            Url = url;
        }

        public virtual long Id { get; init; }

        public virtual string Url { get; init; }
    }
}
