using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RailwayTicketSystem.Data;
using RailwayTicketSystem.Models;

namespace RailwayTicketSystem.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IActionResult Assign()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Assign(string email,string role)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, "Admin");

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Email not found";
                    return View("Assign", "Admin");
                }
            }
            else
            {
                return RedirectToAction("UserNotFound");
            }
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult Train()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrain(TrainDetail Train)
        {
            db.TrainDetails.Add(Train);
            await db.SaveChangesAsync();
            TempData["success"] = "Train added successfully";
            return RedirectToAction("Train");
        }

        [HttpGet]
        public IActionResult ViewTrains()
        {
            var trains = db.TrainDetails.ToList();
            return View(trains);
        }
    }
}
