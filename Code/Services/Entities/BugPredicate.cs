using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class BugPredicate
    {
        public int? Id { get; set; }

        public string Tittle { get; set; }

        public int[] StateId { get; set; }

    }
}
