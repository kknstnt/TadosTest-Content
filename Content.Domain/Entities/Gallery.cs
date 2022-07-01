namespace Content.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Enums;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Gallery : Content
    {
        private readonly ICollection<Image> _images = new HashSet<Image>();

        [Obsolete("Only for reflection", true)]
        public Gallery()
        {
        }

        public Gallery(string name, User user, DateTime dateTimeUtc, Image cover, IEnumerable<Image> images)
            : base(ContentCategory.Gallery, name, user, dateTimeUtc)
        {
            if (cover == null)
                throw new ArgumentNullException(nameof(cover));
            Cover = cover;

            AddImages(images);
        }

        public virtual Image Cover { get; protected set; }

        public virtual IEnumerable<Image> Images => _images;

        public virtual void Update(string name, Image cover, IEnumerable<Image> images)
        {
            SetName(name);

            if (cover == null)
                throw new ArgumentNullException(nameof(cover));
            Cover = cover;

            _images.Clear();
            AddImages(images);
        }

        public virtual void AddImages(IEnumerable<Image> images)
        {
            foreach (var img in images)
                _images.Add(img);
        }
    }
}
