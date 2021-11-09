using Movie.Core.Exception.Base;
using System;

namespace Movie.Core.Exception.DatabaseException
{
    public class DatabaseException : ExceptionBase
    {
        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
