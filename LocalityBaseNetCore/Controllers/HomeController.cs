using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocalityBaseNetCore.Models;
using Microsoft.AspNetCore.Http;
using static LocalityBaseNetCore.LocalitiesStats;

namespace LocalityBaseNetCore.Controllers
{
    public class HomeController : Controller
    {
        private LocalitiesContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(LocalitiesContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            ViewBag.OverallPeople = GetFormattedDecimal(GetOverallPeople(db.GetLocalities()));
            ViewBag.AveragePeople = GetFormattedDecimal(GetAveragePeople(db.GetLocalities()));
            ViewBag.OverallBudget = GetFormattedDecimal(GetOverallBudget(db.GetLocalities()));
            ViewBag.AverageBudget = GetFormattedDecimal(GetAverageBudget(db.GetLocalities()));
            return View(db.GetLocalities());
        }

        public IActionResult _AddLocality()
        {
            ViewBag.id = db.LocalitiesCount() + 1;
            return View();
        }
        
        [HttpPost]
        public string AddLocality(InputLocality loc)
        {
            bool areAllPropsSet = loc.GetType().GetProperties().All(propertyInfo => propertyInfo.GetValue(loc) != null)
                && !(loc.GetType().GetProperties()
                    .Where(pi => pi.GetValue(loc) is string)
                    .Select(pi => (string) pi.GetValue(loc))
                    .Any(value => String.IsNullOrEmpty(value)));
            if(areAllPropsSet)
            {
                if (!Regex.IsMatch(loc.PeopleCount, "\\d+[\\.,]?\\d*"))
                    return $"ERROR: People Count is not a number, please try again";
                if (!Regex.IsMatch(loc.Budget, "\\d+[\\.,]?\\d*"))
                    return $"ERROR: Budget is not a number, please try again";
                db.AddLocality(new Locality(loc));
                return $"Added new locality: {loc.Name}, type: {loc.Type}";
            }

            return $"ERROR: some property/ies is/are null, please try again";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}