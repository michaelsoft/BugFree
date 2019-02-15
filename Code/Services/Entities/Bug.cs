using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class Bug
    {
        public int BugId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }

    }
}
