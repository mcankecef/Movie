using Movie.Core.Exception.Base;
using System;

namespace Movie.Core.Exception.BusinessException
{
    public class BusinessException : ExceptionBase
    {
        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
