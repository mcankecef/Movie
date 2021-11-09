using System;

namespace Movie.Core.Exception.Base
{
    public class ExceptionBase : System.Exception
    {
        public ExceptionBase(string message) : base(message)
        {
        }

        public ExceptionBase(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
