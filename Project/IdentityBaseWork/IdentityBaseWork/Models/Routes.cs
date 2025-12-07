using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityBaseWork.Models
{
    public class Routes
    {
        [Key]
        public int RouteID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string StartingLocation { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string DestinationLocation { get; set; }

        public int Distance { get; set; }
        public TimeSpan TravelTime { get; set; }
    }
}
