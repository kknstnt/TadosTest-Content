﻿namespace Content.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::Domain.Abstractions;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class City : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public City()
        {
        }

        protected internal City(string name, Country country)
        {
            Update(name, country);
        }

        public virtual long Id { get; init; }

        public virtual string Name { get; protected set; }

        public virtual Country Country { get; protected set; }

        public virtual void Update(string name, Country country)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            if (country == null)
                throw new ArgumentNullException(nameof(country));

            Name = name;
            Country = country;
        }
    }
}
