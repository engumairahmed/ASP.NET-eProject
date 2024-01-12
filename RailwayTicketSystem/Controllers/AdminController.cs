using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayTicketSystem.Data;
using RailwayTicketSystem.Models;
using RailwayTicketSystem.Models.ViewModels;

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

        public IActionResult Compartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompartment(Compartment Class)
        {
            db.Compartments.Add(Class);
            await db.SaveChangesAsync();
            TempData["Success"] = "Compartment added successfully";
            return RedirectToAction("Compartment");
        }
        [HttpGet]
        public IActionResult ViewCompartment()
        {
            var res = db.Compartments.ToList();
            return View(res);
        }

        public IActionResult Train()
        {
            var trains = db.Trains.ToList();
            var compartments = db.Compartments.ToList();
            var coaches = db.Coaches.Include(t=>t.Compartment).ToList();
            var train = new Train
            {
                Coaches = coaches,                
            };
            var viewModel = new TrainAddModel { 
                Trains = trains, 
                Coaches = coaches, 
                Compartments = compartments 
            };
            return View();
        }

        //public IActionResult Train()
        //{
        //    var compartments = db.Compartments.ToList();
        //    //var viewModel = new TrainAddModel { Coaches = new List<Coach>(), Compartments = compartments };
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> AddTrain(Train model)
        {
            //var newTrain = new Train
            //{
            //    TrainName = model.Train.TrainName,
            //    TrainNo = model.Train.TrainNo,
            //    Coaches = new List<Coach>()
            //};
            db.Trains.Add(model);
            await db.SaveChangesAsync();
            TempData["success"] = "Train added successfully";
            return RedirectToAction("Train");
        }

        [HttpGet]
        public IActionResult ViewTrains()
        {
            var res = db.Trains.ToList();

            var compartments = db.Compartments.ToList();
            var coaches = db.Coaches.ToList();
            var viewModel = new TrainAddModel
            {
                Trains = res,
                Coaches = coaches,
                Compartments = compartments
            };

            return View(res);
        }
        public IActionResult TrainDetail(int id)
        {
            var res = db.Coaches
        .Include(coach => coach.Train)
        .Include(coach => coach.Compartment)
        .Where(coach => coach.TrainId == id)
        .ToList();
            return View(res);
        }
        public IActionResult Coach()
        {
            var trains = db.Trains.ToList();
            var compartments = db.Compartments.ToList();
            var coaches = db.Coaches.ToList();
            var viewModel = new TrainAddModel {
                Trains=trains, 
                Coaches = coaches, 
                Compartments = compartments 
            };
            return View(viewModel);
        }

        public async Task<IActionResult> AddCoach(TrainAddModel model)
        {
            var coach = new Coach()
            {
                CoachNumber = model.Coach.CoachNumber,
                TrainId=model.Coach.TrainId,
                CompartmentId=model.Coach.CompartmentId,
                TotalSeats=model.Coach.TotalSeats
            };
            db.Coaches.Add(coach);
            await db.SaveChangesAsync();
            TempData["success"] = "Coach added successfully";
            return RedirectToAction("Coach");
        }

        public IActionResult Station()
        {
            return View();
        }

        public async Task<IActionResult> AddStation(Station station)
        {
            db.Stations.Add(station);
            await db.SaveChangesAsync();
            TempData["success"] = "Station added successfully";
            return RedirectToAction("Station");

        }
        public IActionResult ViewStations()
        {
            var res=db.Stations.ToList();
            return View(res)
;        }
        public IActionResult StationDistance()
        {

            var res = db.Stations.ToList();
            var DistanceModel = new DistanceAddModel()
            {
                Stations=res,
            };
            return View(DistanceModel);
        }

        public async Task<IActionResult> AddDistance(DistanceAddModel model)
        {
            var SD = new StationDistance()
           {
                FromStationId = model.SD.FromStationId,
                ToStationId = model.SD.ToStationId,
                Distance = model.SD.Distance
           };
            db.Add(SD);
            await db.SaveChangesAsync();
            TempData["success"] = "Distance Added Successfully";
            return RedirectToAction("StationDistance");
        }
        public IActionResult FareRules()
        {
            var fare=db.FareDetails.ToList();
            var train = db.Trains.ToList();
            var compartment = db.Compartments.ToList();
            var model = new FareAddModel()
            {
                FareDetails = fare,
                Trains = train,
                Compartments = compartment
            };
            return View(model);
        }

        public async Task<IActionResult> AddFare(FareAddModel model)
        {
            var Fare = new FareDetail()
            {
                Train=model.FareDetail.Train,
                Compartment=model.FareDetail.Compartment,
                BaseCharges=model.FareDetail.BaseCharges,
                DistanceCharges=model.FareDetail.DistanceCharges
            };
            db.FareDetails.Add(Fare);
            await db.SaveChangesAsync();
            TempData["success"] = "Rule Added Successfully";
            return RedirectToAction("FareRules");
        }
    }
}
