using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Models
{
    public class User : IdentityUser
    {

        [Column("FirstName")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [MaxLength(64)]
        public string LastName { get; set; }
    }
}
