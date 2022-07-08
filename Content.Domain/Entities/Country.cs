namespace Content.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::Domain.Abstractions;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class Country : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Country()
        {
        }

        protected internal Country(string name)
        {
            SetName(name);
        }

        public virtual long Id { get; init; }

        public virtual string Name { get; protected set; }

        public virtual void Update(string name)
        {
            SetName(name);
        }

        protected internal virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }
    }
}
