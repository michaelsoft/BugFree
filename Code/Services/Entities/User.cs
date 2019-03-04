using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        //[InverseProperty("AssignedTo")]
        //public List<Bug> AssignedBugs { get; set; }

        //[InverseProperty("CreatedBy")]
        //public List<Bug> CreatedBugs { get; set; }

    }

}
