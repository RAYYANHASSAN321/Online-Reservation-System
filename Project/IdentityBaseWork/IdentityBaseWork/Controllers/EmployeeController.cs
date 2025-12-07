using IdentityBaseWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
namespace IdentityBaseWork.Controllers
{
    [Authorize(Roles = SD.Role_Branch_Manager)]
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext appDbContext;
        
        public EmployeeController(ApplicationDbContext _appDbContext, IWebHostEnvironment _webHostEnvironment)
        {
            appDbContext = _appDbContext;
            this.webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
       // [Authorize(Roles = SD.Role_Admin)]
        //list of Routes
        public IActionResult routes_List()
        {
            var data = appDbContext.Routes.ToList();
            return View(data);
        }
        //List of Bus
        public IActionResult Bus_List()
        {
            var data = appDbContext.Bus.Include(x => x.Route).ToList();
            return View(data);
        }
        //List of Bus Seat
        public IActionResult BusSeatList()
        {
            var data = appDbContext.BusSeats.Include(x => x.Bus).ToList();
            return View(data);
        }
        //list of Agegroup
        public IActionResult Age_List()
        {
            var data = appDbContext.AgeGroups.ToList();
            return View(data);
        }

        public IActionResult BookingList()
        {
            //var data = appDbContext.Bus.Include(x => x.Route).ToList();
            var data = appDbContext.Bookings.Include(b => b.Bus).Include(a => a.AgeGroup).Include(c => c.appuser).ToList();
            return View(data);
        }



        // Delete work for Booking
        public IActionResult Booking_Delete(int id)
        {
            var deleteDetail = appDbContext.Bookings.Find(id);
            return View(deleteDetail);
        }
        [HttpPost, ActionName("Booking_Delete")]
        public IActionResult Booking_Delete2(int id)
        {
            var confirm_delete = appDbContext.Bookings.Find(id);
            if (confirm_delete != null)
            {
                appDbContext.Bookings.Remove(confirm_delete);
                appDbContext.SaveChanges();
                return RedirectToAction("BookingList", "Admin");
            }
            return View();
        }

        // details work for Bookings
        public IActionResult Book_Details(int id)
        {
            var detailData = appDbContext.Bookings.Find(id);
            return View(detailData);
        }
    }
}
