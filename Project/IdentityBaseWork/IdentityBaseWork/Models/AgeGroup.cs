using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityBaseWork.Models
{
    public class AgeGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string GroupName { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Discount { get; set; }
    }
}
