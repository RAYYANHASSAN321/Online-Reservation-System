using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace IdentityBaseWork.Models
{
    public class Bus
    {
        [Key]
        public int BusID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string BusNumber { get; set; }

        [Required]
        public string BusType { get; set; }

        public int TotalSeatNumber { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceFactor { get; set; }

        [NotMapped]
        public IFormFile BusProImg { get; set; }
        public string BusImgName { get; set; }

        [ForeignKey("Route")]
        public int RouteID { get; set; }
        public virtual Routes Route { get; set; }
    }
}
