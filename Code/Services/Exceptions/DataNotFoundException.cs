using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Exceptions
{
    public class DataNotFoundException : BugFreeException
    {
        public DataNotFoundException(string message) : base(message)
        {

        }
    }
}
