using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Models
{
    public class Role : IdentityRole
    {
        [Column("Name")]
        [MaxLength(64)]
        public string Name { get; set; }

    }
}
      