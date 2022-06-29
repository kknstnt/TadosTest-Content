namespace Content.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Enums;
    using ValueObjects;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Gallery : Content
    {
        private readonly ICollection<Image> _images = new HashSet<Image>();

        [Obsolete("Only for reflection", true)]
        public Gallery()
        {
        }

        protected internal Gallery(string name, User user, DateTime dateTimeUtc, Image cover)
            : base(ContentType.Article, name, user, dateTimeUtc)
        {
            if (cover == null)
                throw new ArgumentOutOfRangeException(nameof(cover));

            Cover = cover;
        }

        public virtual Image Cover { get; init; }

        public virtual IEnumerable<Image> Images => _images;

        protected internal void AddImage(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            _images.Add(image);
        }
    }
}
