using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityBaseWork.Models
{
    public class BusSeat
    {
        [Key]
        public int BusSeatID { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        public bool IsAvailable { get; set; } = true;

        [ForeignKey("Bus")]
        public int BusID { get; set; }
        public virtual Bus Bus { get; set; }

        //[ForeignKey("Booking")]
        //public int? BookingID { get; set; }
        //public virtual Booking Booking { get; set; }
    }
}
