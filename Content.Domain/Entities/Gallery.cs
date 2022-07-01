namespace Content.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Enums;
    using Domain.ValueObjects;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Gallery : Content
    {
        private readonly ICollection<Image> _images = new HashSet<Image>();

        [Obsolete("Only for reflection", true)]
        public Gallery()
        {
        }

        public Gallery(string name, User user, DateTime dateTimeUtc, Image cover)
            : base(ContentCategory.Gallery, name, user, dateTimeUtc)
        {
            if (cover == null)
                throw new ArgumentNullException(nameof(cover));
            Cover = cover;
        }

        public virtual Image Cover { get; protected set; }

        public virtual IEnumerable<Image> Images => _images;

        public virtual void Update(string name, Image cover, List<string> imagesUrls)
        {
            SetName(name);

            if (cover == null)
                throw new ArgumentNullException(nameof(cover));
            Cover = cover;

            _images.Clear();
            foreach (var url in imagesUrls)
                AddImage(url);
        }

        public virtual void AddImage(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));
            _images.Add(new Image(url));
        }
    }
}
