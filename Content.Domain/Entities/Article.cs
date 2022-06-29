namespace Content.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Enums;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Article : Content
    {
        [Obsolete("Only for reflection", true)]
        public Article()
        {
        }

        protected internal Article(string name, User user, DateTime dateTimeUtc, string text)
            : base(ContentType.Article, name, user, dateTimeUtc)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentOutOfRangeException(nameof(text));

            Text = text;
        }

        public virtual string Text { get; init; }
    }
}
