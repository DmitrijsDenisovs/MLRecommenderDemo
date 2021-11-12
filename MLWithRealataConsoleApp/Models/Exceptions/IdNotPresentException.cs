using System;
using System.Collections.Generic;
using System.Text;

namespace MLWithRealataConsoleApp.Models.Exceptions
{
    class IdNotPresentException : Exception
    {
        public IdNotPresentException()
        {
        }

        public IdNotPresentException(string message)
            : base(message)
        {
        }

        public IdNotPresentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
