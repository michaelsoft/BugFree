using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class AppUser : IdentityUser
    {

        [NotMapped]
        public Guid UserId
        {
            get { return Guid.Parse(this.Id); }
        }

        [NotMapped]
        public string Password { get; set; }
    }
}
