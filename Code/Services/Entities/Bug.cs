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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Tittle { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public BugState State { get; set; }

        public List<BugAttachment> Attachments { get; set; }

        public Guid? AssignedTo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset CreatedOn { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }


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
