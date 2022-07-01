namespace Content.WebApi.Exceptions
{
    using System;

    public class IncorrectRequestParameters : Exception
    {
        private const string DefaultMessage = "Incorrect request parameters";

        public IncorrectRequestParameters()
            : base(DefaultMessage)
        {
        }
    }
}
