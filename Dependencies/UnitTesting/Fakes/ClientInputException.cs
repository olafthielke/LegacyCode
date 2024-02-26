using System;

namespace Dependencies.UnitTesting.Fakes
{
    public abstract class ClientInputException : Exception
    {
        protected ClientInputException()
        { }

        protected ClientInputException(string message)
            : base(message)
        { }
    }
}