using IdentityBaseWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace IdentityBaseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext appDbContext;

        public HomeController(ApplicationDbContext _appDbContext, IWebHostEnvironment _webHostEnvironment)
        {
            appDbContext = _appDbContext;
            this.webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Indexx()
        {
            return View();
        }
		public IActionResult Index()
		{
			return View();
		}
        [Authorize(Roles = SD.Role_User_Customer)]

        public IActionResult About_Us()
		{
			return View();
		}
        [Authorize(Roles = SD.Role_User_Customer)]

        public IActionResult Pricing()
        {
            return View();
        }
        [Authorize(Roles = SD.Role_User_Customer)]

        // add method for booking booking
        public IActionResult Booking()
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
		public IActionResult Booking(Booking Book)
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
			return RedirectToAction("Indexx", "Home");
			//return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
