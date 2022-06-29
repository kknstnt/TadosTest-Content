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

        protected internal User(string login, City city)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(login));

            if (city == null)
                throw new ArgumentNullException(nameof(city));

            Login = login;
            City = city;
        }

        public virtual long Id { get; init; }

        public virtual string Login { get; init; }

        public virtual City City { get; init; }
    }
}
