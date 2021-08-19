using System.Collections.Generic;

namespace Testes.Bench
{
    public class ErrorMessage
    {
        public string Tag { get; set; }
        public string Message { get; set; }
    }

    public class Error
    {
        public IEnumerable<ErrorMessage> ErrorMessages { get; }
        public Error(IEnumerable<ErrorMessage> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
