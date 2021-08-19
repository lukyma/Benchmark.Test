using System;

namespace Testes.Bench
{
    public class ValidateException : Exception
    {
        public ValidateException(Error error)
        {
            Error = error;
        }
        public Error Error { get; }
    }
}
