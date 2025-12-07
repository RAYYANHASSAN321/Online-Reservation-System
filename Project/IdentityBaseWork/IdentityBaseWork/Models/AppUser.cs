using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityBaseWork.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Column(TypeName ="varchar(15)")]
        public string Contact { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string City { get; set; }


        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Country { get; set; }
    }
}
