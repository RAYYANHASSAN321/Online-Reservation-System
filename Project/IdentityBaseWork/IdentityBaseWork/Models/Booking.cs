using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityBaseWork.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime TravelDate { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }


        public String CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual AppUser appuser { get; set; }


        [ForeignKey("Bus")]
        public int BusID { get; set; }
        public virtual Bus Bus { get; set; }

        [ForeignKey("AgeGroup")]
        public int AgeGroupId { get; set; }
        public virtual AgeGroup AgeGroup { get; set; }

        [NotMapped]
        public bool IsSeatAvailable { get; set; }
    }
}
