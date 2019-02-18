using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Exceptions
{
    public class BugFreeException : ApplicationException
    {
        public BugFreeException()
        {

        }

        public BugFreeException(string message) : base(message)
        {

        }
    }
}
