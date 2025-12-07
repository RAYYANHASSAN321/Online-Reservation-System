using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityBaseWork.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<BusSeat> BusSeats { get; set; }
        public DbSet<Routes> Routes { get; set; }

    }
}
