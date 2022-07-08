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

        public Gallery(string name, User user, DateTime dateTimeUtc, string coverUrl)
            : base(ContentCategory.Gallery, name, user, dateTimeUtc)
        {
            SetCoverUrl(coverUrl);
        }

        public virtual string CoverUrl { get; protected set; }

        public virtual IEnumerable<Image> Images => _images;

        public virtual void Update(string name, string coverUrl, List<string> imagesUrls)
        {
            SetName(name);
            SetCoverUrl(coverUrl);

            foreach (var image in _images)
                _images.Remove(image);
            foreach (var url in imagesUrls)
                AddImage(url);
        }

        protected internal virtual void AddImage(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));
            _images.Add(new Image(url));
        }

        protected internal virtual void SetCoverUrl(string coverUrl)
        {
            if (string.IsNullOrWhiteSpace(coverUrl))
                throw new ArgumentNullException(nameof(coverUrl));

            CoverUrl = coverUrl;
        }
    }
}
