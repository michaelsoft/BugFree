using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class AppUser : IdentityUser
    {
        [NotMapped]
        public string Password { get; set; }
    }
}
