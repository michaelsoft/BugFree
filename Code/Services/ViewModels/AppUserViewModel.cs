using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class AppUserViewModel
    {
        //
        // Summary:
        //     Gets or sets the user name for this user.
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public virtual string UserName { get; set; }

        //
        // Summary:
        //     Gets or sets the normalized user name for this user.
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public virtual string NormalizedUserName { get; set; }

        public virtual string Password { get; set; }

        //
        // Summary:
        //     Gets or sets the email address for this user.
        [MaxLength(100)]
        public virtual string Email { get; set; }

        [MaxLength(50)]
        public virtual string PhoneNumber { get; set; }
        //
        // Summary:
        //     A random value that must change whenever a users credentials change (password
        //     changed, login removed)
        public virtual string SecurityStamp { get; set; }

        public string Token { get; set; }

        public List<string> Roles { get; set; }
    }
}