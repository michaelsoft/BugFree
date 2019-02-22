using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MichaelSoft.BugFree.WebApi.ViewModels
{
    public class BugViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tittle { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public BugStateViewModel State { get; set; }

        public List<BugAttachmentViewModel> Attachments { get; set; }

    }

    public enum BugStateViewModel : int
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
