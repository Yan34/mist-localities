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
            ViewBag.OverallPeople = GetOverallPeopleStr();
            ViewBag.AveragePeople = GetAveragePeopleStr();
            ViewBag.OverallBudget = GetOverallBudgetStr();
            ViewBag.AverageBudget = GetAverageBudgetStr();
            return View(db.Localities.ToList());
        }

        private decimal GetOverallPeople()
        {
            List<Locality> locs = db.Localities.ToList();
            decimal OverallPeople=0;
            if(locs.Count!=0)
            {
                foreach (var loc in locs)
                {
                    OverallPeople += loc.PeopleCount;
                }
            }
            
            return OverallPeople;
        }

        public string GetOverallPeopleStr()
        {
            decimal OverallPeople = GetOverallPeople();
            string OverallPeopleStr = "";
            OverallPeopleStr = OverallPeople.ToString();
            OverallPeopleStr = OverallPeopleStr.TrimEnd('0').TrimEnd(',');
            
            return OverallPeopleStr;
        }

        private decimal GetOverallBudget()
        {
            List<Locality> locs = db.Localities.ToList();
            decimal OverallBudget=0;
            if(locs.Count!=0)
            {
                foreach (var loc in locs)
                {
                    OverallBudget += loc.Budget;
                }
            }
            
            return OverallBudget;
        }

        public string GetOverallBudgetStr()
        {
            decimal OverallBudget = GetOverallBudget();
            string OverallBudgetStr = "";
            OverallBudgetStr = OverallBudget.ToString();
            OverallBudgetStr = OverallBudgetStr.TrimEnd('0').TrimEnd(',');
            
            return OverallBudgetStr;
        }

        private decimal GetAveragePeople()
        {
            int locsCount = db.Localities.Count();
            decimal AveragePeople = 0;
            if (locsCount != 0)
            {
                AveragePeople = decimal.Divide(GetOverallPeople(), locsCount);
            }

            return AveragePeople;
        }

        public string GetAveragePeopleStr()
        {
            decimal AveragePeople = GetAveragePeople();
            string AveragePeopleStr = "";
            AveragePeopleStr = AveragePeople.ToString();
            AveragePeopleStr = AveragePeopleStr.TrimEnd('0').TrimEnd(',');
            
            return AveragePeopleStr;
        }

        private decimal GetAverageBudget()
        {
            int locsCount = db.Localities.Count();
            decimal AverageBudget = 0;
            if (locsCount != 0)
            {
                AverageBudget = decimal.Divide(GetOverallBudget(), locsCount);
            }

            return AverageBudget;
        }

        public string GetAverageBudgetStr()
        {
            decimal AverageBudget = GetAverageBudget();
            string AverageBudgetStr = "";
            AverageBudgetStr = AverageBudget.ToString();
            AverageBudgetStr = AverageBudgetStr.TrimEnd('0').TrimEnd(',');
            
            return AverageBudgetStr;
        }

        public IActionResult _AddLocality()
        {
            ViewBag.id = db.Localities.Count() + 1;
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
                db.Add(new Locality(loc));
                db.SaveChanges();
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