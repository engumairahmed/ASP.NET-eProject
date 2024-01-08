using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize(Roles ="Admin")]
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
