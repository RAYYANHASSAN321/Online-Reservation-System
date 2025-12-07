using IdentityBaseWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Security.Claims;

namespace IdentityBaseWork.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext appDbContext;

        public AdminController(ApplicationDbContext _appDbContext, IWebHostEnvironment _webHostEnvironment)
        {
            appDbContext = _appDbContext;
            this.webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Routes to database
        //[Authorize(Roles = SD.Role_Admin)]

        public IActionResult AddRoutes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRoutes(Routes r)
        {
            appDbContext.Routes.Add(r);
            appDbContext.SaveChanges();
            return RedirectToAction("routes_List", "Admin");
        }
        //list of database
        public IActionResult routes_List()
        {
            var data = appDbContext.Routes.ToList();
            return View(data);
        }
        // details work for Routes table
        public IActionResult routes_Details(int id)
        {
            var detailData = appDbContext.Routes.Find(id);
            return View(detailData);
        }
        // Delete work for Routes table
        public IActionResult Delete(int id)
        {
            var deleteDetail = appDbContext.Routes.Find(id);
            return View(deleteDetail);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete2(int id)
        {
            var confirm_delete = appDbContext.Routes.Find(id);
            if (confirm_delete != null)
            {
                appDbContext.Routes.Remove(confirm_delete);
                appDbContext.SaveChanges();
                return RedirectToAction("routes_List", "Admin");
            }
            return View();
        }
        // Edit work for Routes table
        public IActionResult routesEdit(int id)
        {
            var editData = appDbContext.Routes.Find(id);
            return View(editData);
        }
        [HttpPost]
        public IActionResult routesEdit(int id, Routes root)
        {
            appDbContext.Routes.Update(root);
            appDbContext.SaveChanges();
            return RedirectToAction("Routes_List", "Admin");
        }
        //Bus to database
        public IActionResult AddBus()
        {
            ViewBag.Rou = appDbContext.Routes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddBus(Bus B)
        {
            string filename = "";
            if (B.BusProImg != null)
            {
                //Creating a path where image should upload
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Content/Images");

                //creating image name with a random number
                filename = Guid.NewGuid().ToString() + "_" + B.BusProImg.FileName;
                string filepath = Path.Combine(uploadFolder, filename);
                B.BusProImg.CopyTo(new FileStream(filepath, FileMode.Create));
                Bus bus = new Bus()
                {
                    BusNumber = B.BusNumber,
                    BusType = B.BusType,
                    TotalSeatNumber = B.TotalSeatNumber,
                    DepartureTime = B.DepartureTime,
                    ArrivalTime = B.ArrivalTime,
                    PriceFactor = B.PriceFactor,
                    RouteID = B.RouteID,
                    BusImgName = filename
                };
                appDbContext.Bus.Add(bus);
                appDbContext.SaveChanges();
            }
            return RedirectToAction("Bus_List", "Admin");
        }
        //List of Bus
        public IActionResult Bus_List()
        {
            var data = appDbContext.Bus.Include(x => x.Route).ToList();
            return View(data);
        }
        // details work for Bus table
        public IActionResult Bus_Details(int id)
        {
            var detailData = appDbContext.Bus.Find(id);
            return View(detailData);
        }
        // Delete work for Bus table
        public IActionResult BusDelete(int id)
        {
            var deleteDetail = appDbContext.Bus.Find(id);
            return View(deleteDetail);
        }
        [HttpPost, ActionName("BusDelete")]
        public IActionResult BusDelete2(int id)
        {
            var confirm_delete = appDbContext.Bus.Find(id);
            if (confirm_delete != null)
            {
                appDbContext.Bus.Remove(confirm_delete);
                appDbContext.SaveChanges();
                return RedirectToAction("Bus_List", "Admin");
            }
            return View();
        }
        // Edit work for Bus table
        public IActionResult BusEdit(int id)
        {
            ViewBag.Rou = appDbContext.Routes.ToList();
            var editData = appDbContext.Bus.Find(id);
            return View(editData);
        }
        [HttpPost]
        public IActionResult BusEdit(int id, Bus B)
        {
            appDbContext.Bus.Update(B);
            appDbContext.SaveChanges();
            return RedirectToAction("Bus_List", "Admin");
        }
        //add work of Bus seat
        public IActionResult AddSeat()
        {
            ViewBag.Bus = appDbContext.Bus.ToList();
            ViewBag.Book = appDbContext.Bookings.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddSeat(BusSeat BS)
        {
            appDbContext.BusSeats.Add(BS);
            appDbContext.SaveChanges();
            return RedirectToAction("BusSeatList", "Admin");
        }
        //List of Bus Seat
        public IActionResult BusSeatList()
        {
            var data = appDbContext.BusSeats.Include(x => x.Bus).ToList();
            return View(data);
        }
        // details work for Bus Seat
        public IActionResult BusSeat_Details(int id)
        {
            var detailData = appDbContext.BusSeats.Find(id);
            return View(detailData);
        }
        // Edit work for Bus Seat table
        public IActionResult Seat_Edit(int id)
        {
            var editData = appDbContext.BusSeats.Find(id);
            return View(editData);
        }
        [HttpPost]
        public IActionResult Seat_Edit(int id, BusSeat BS)
        {
            appDbContext.BusSeats.Update(BS);
            appDbContext.SaveChanges();
            return RedirectToAction("BusSeatList", "Admin");
        }
        //add work of AgeGroup
        public IActionResult AddAgeGroup()
        {
            //ViewBag.Bus = appDbContext.Bookings.ToList();
            //ViewBag.Book = appDbContext.Bookings.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddAgeGroup(AgeGroup Age)
        {
            appDbContext.AgeGroups.Add(Age);
            appDbContext.SaveChanges();
            return RedirectToAction("Age_List", "Admin");
        }
        //list of Agegroup
        public IActionResult Age_List()
        {
            var data = appDbContext.AgeGroups.ToList();
            return View(data);
        }
        // details work for Agegroup
        public IActionResult Age_Details(int id)
        {
            var detailData = appDbContext.AgeGroups.Find(id);
            return View(detailData);
        }
        // Delete work for AgeGroup
        public IActionResult Age_Delete(int id)
        {
            var deleteDetail = appDbContext.AgeGroups.Find(id);
            return View(deleteDetail);
        }
        [HttpPost, ActionName("Age_Delete")]
        public IActionResult Age_Delete2(int id)
        {
            var confirm_delete = appDbContext.AgeGroups.Find(id);
            if (confirm_delete != null)
            {
                appDbContext.AgeGroups.Remove(confirm_delete);
                appDbContext.SaveChanges();
                return RedirectToAction("Age_List", "Admin");
            }
            return View();
        }
        // add method for booking booking
        public IActionResult AddSBooking()
        {
            // Fetch buses
            ViewBag.Bus = appDbContext.Bus.ToList();

            // Fetch age groups
            ViewBag.Age = appDbContext.AgeGroups.ToList();

            // Fetch only available seats
            var availableSeats = appDbContext.BusSeats
                                 .Where(bs => bs.IsAvailable)
                                 .ToList();

            ViewBag.AvailableSeats = availableSeats;

            return View();
        }

        [HttpGet]
        public IActionResult GetAvailableSeats(int busId)
        {
            var availableSeats = appDbContext.BusSeats
                                  .Where(bs => bs.BusID == busId && bs.IsAvailable)
                                  .Select(bs => new
                                  {
                                      busSeatID = bs.BusSeatID, // Key to uniquely identify the seat
                                      seatNumber = bs.SeatNumber // Displayable seat number
                                  })
                                  .ToList();

            return Json(availableSeats);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddSBooking(Booking Book)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Book.CustomerID = claims.Value;

            var bus = appDbContext.Bus.FirstOrDefault(b => b.BusID == Book.BusID);
            var basePrice = bus.PriceFactor;
            var age = appDbContext.AgeGroups.FirstOrDefault(a => a.GroupId == Book.AgeGroupId);
            var ageDisc = age.Discount;

            var discountAmount = (basePrice * ageDisc) / 100;
            Book.TotalPrice = basePrice - discountAmount;

            // Update the seat availability
            var selectedSeat = appDbContext.BusSeats.FirstOrDefault(bs => bs.BusSeatID == Book.SeatNumber);
            if (selectedSeat != null)
            {
                selectedSeat.IsAvailable = false;
            }


            appDbContext.Bookings.Add(Book);
            appDbContext.SaveChanges();
            return RedirectToAction("BookingList", "Admin");
            //return View();
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
