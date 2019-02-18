using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Entities
{

    public class Bug : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Tittle { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public BugState State { get; set; }

        public List<BugAttachment> Attachments { get; set; }

    }

    public enum BugState : int
    {
        New = 1,
        Confirmed,
        Assigned,
        Fixing,
        Fixed,
        Verified,
        Closed,
        Default = New
    }
}
