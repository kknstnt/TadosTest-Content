namespace Content.Domain.Exceptions
{
    using System;
    using global::Domain.Abstractions;

    public class UserAlreadyRatesThisContentException : Exception, IDomainException
    {
        private const string DefaultMessage = "User already rates this content";

        public UserAlreadyRatesThisContentException()
            : base(DefaultMessage)
        {
        }
    }
}
