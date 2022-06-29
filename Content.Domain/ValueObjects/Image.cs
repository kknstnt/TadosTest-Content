namespace Content.Domain.ValueObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::Domain.Abstractions;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Image : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Image()
        {
        }

        protected internal Image(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(uri));

            URI = uri;
        }

        public virtual long Id { get; set; }

        public virtual string URI { get; init; }
    }
}
