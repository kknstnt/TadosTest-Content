namespace Content.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::Domain.Abstractions;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class User : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public User()
        {
        }

        protected internal User(string email, City city)
        {
            Update(email, city);
        }

        public virtual long Id { get; init; }

        public virtual string Email { get; protected set; }

        public virtual City City { get; protected set; }

        public virtual void Update(string email, City city)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));

            if (city == null)
                throw new ArgumentNullException(nameof(city));

            Email = email;
            City = city;
        }
    }
}
