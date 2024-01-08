using Microsoft.AspNetCore.Mvc;

namespace RailwayTicketSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserDashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
