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
            SetEmail(email);
            SetCity(city);
        }

        public virtual long Id { get; init; }

        public virtual string Email { get; protected set; }

        public virtual City City { get; protected set; }

        public virtual void Update(string email, City city)
        {
            SetEmail(email);
            SetCity(city);
        }

        protected internal virtual void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));

            Email = email;
        }

        protected internal virtual void SetCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));

            City = city;
        }
    }
}
