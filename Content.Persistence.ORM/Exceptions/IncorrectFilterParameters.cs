namespace Content.Persistence.ORM.Exceptions
{
    using System;
    internal class IncorrectFilterParameters : Exception
    {
        private const string DefaultMessage = "Incorrect pagination parameters";

        public IncorrectFilterParameters()
            : base(DefaultMessage)
        {
        }
    }
}
