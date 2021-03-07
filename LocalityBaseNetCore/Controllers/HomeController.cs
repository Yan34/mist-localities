using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocalityBaseNetCore.Models;

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
            List<Locality> locs = db.Localities.ToList();
            LocalityList locList = new LocalityList();
            locList.Localities = locs;
            locList.locsCount = locs.Count;
            decimal OverallPeople=0, OverallBudget=0, AveragePeople=0, AverageBudget=0;
            if(locList.locsCount!=0)
            {
                foreach (var loc in locs)
                {
                    OverallPeople += loc.PeopleCount;
                    OverallBudget += loc.Budget;
                }
                AveragePeople = decimal.Divide(OverallPeople, locList.locsCount);
                AverageBudget = decimal.Divide(OverallBudget, locList.locsCount);
            }

            string OverallPeopleStr="", OverallBudgetStr="", AveragePeopleStr="", AverageBudgetStr="";
            string[] strVals = {OverallPeopleStr, OverallBudgetStr, AveragePeopleStr, AverageBudgetStr};
            decimal[] decVals = { OverallPeople, OverallBudget, AveragePeople, AverageBudget };
            for (int i=0; i<4; i++)
            {
                strVals[i] = decVals[i].ToString();
                strVals[i] = strVals[i].TrimEnd('0').TrimEnd(',');
            }

            locList.OverallPeople = strVals[0];
            locList.OverallBudget = strVals[1];
            locList.AveragePeople = strVals[2];
            locList.AverageBudget = strVals[3];
            
            return View(locList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}