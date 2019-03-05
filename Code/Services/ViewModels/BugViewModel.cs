using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MichaelSoft.BugFree.WebApi.Entities;

namespace MichaelSoft.BugFree.WebApi.ViewModels
{
    public class BugViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Tittle { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public BugStateViewModel State { get; set; }

        public List<BugAttachmentViewModel> Attachments { get; set; }

        public Guid? AssignedTo { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset CreatedOn { get; set; }

        public Guid CreatedBy { get; set; }

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
