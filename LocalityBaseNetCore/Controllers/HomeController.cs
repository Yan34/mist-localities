using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocalityBaseNetCore.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using static LocalityBaseNetCore.LocalitiesStats;

namespace LocalityBaseNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly LocalitiesContext _db;
        private readonly ILogger<HomeController> _logger;

        private readonly string _url = "https://localhost:44331/api/Localities/";
        HttpClient client = new HttpClient();

        public HomeController(LocalitiesContext context, ILogger<HomeController> logger)
        {
            _db = context;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var locs = JsonConvert.DeserializeObject<IEnumerable<Locality>>(
                await client.GetStringAsync(_url));
            ViewBag.OverallPeople = GetFormattedDecimal(GetOverallPeople(locs));
            ViewBag.AveragePeople = GetFormattedDecimal(GetAveragePeople(locs));
            ViewBag.OverallBudget = GetFormattedDecimal(GetOverallBudget(locs));
            ViewBag.AverageBudget = GetFormattedDecimal(GetAverageBudget(locs));
            return View(locs);
        }

        public IActionResult _AddLocality()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddLocality(InputLocality loc)
        {
            bool areAllPropsSet = loc.GetType().GetProperties().All(propertyInfo => propertyInfo.GetValue(loc) != null)
                && !(loc.GetType().GetProperties()
                    .Where(pi => pi.GetValue(loc) is string)
                    .Select(pi => (string) pi.GetValue(loc))
                    .Any(value => String.IsNullOrEmpty(value)));
            if(areAllPropsSet)
            {
                if (!Regex.IsMatch(loc.PeopleCount, "^\\d+[\\.,]?\\d*$"))
                    throw new Exception("People Count is not a number, please try again");
                if (!Regex.IsMatch(loc.Budget, "^\\d+[\\.,]?\\d*$"))
                    throw new Exception("Budget is not a number, please try again");
                var answer = await client.PostAsync(_url+"Add", new StringContent(JsonConvert.SerializeObject(new Locality(loc)), Encoding.Default, "application/json-patch+json"));
                // return $"Added new locality: {loc.Name}, type: {loc.Type}";
                if (answer.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                throw new Exception(answer.ReasonPhrase);
            }
            // return RedirectToAction("Index");
            throw new Exception("Some property/ies is/are null, please try again");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocality(int id)
        {
            var loc = JsonConvert.DeserializeObject<Locality>(await client.GetStringAsync(_url + id));
            return View(new InputLocality(loc));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocality(InputLocality loc)
        {
            bool areAllPropsSet = loc.GetType().GetProperties().All(propertyInfo => propertyInfo.GetValue(loc) != null)
                                  && !(loc.GetType().GetProperties()
                                      .Where(pi => pi.GetValue(loc) is string)
                                      .Select(pi => (string)pi.GetValue(loc))
                                      .Any(value => string.IsNullOrEmpty(value)));
            if (!areAllPropsSet) throw new Exception("Some property/ies is/are null, please try again");
            if (!Regex.IsMatch(loc.PeopleCount, "^\\d+[\\.,]?\\d*$"))
                throw new Exception("People Count is not a number, please try again");
            if (!Regex.IsMatch(loc.Budget, "^\\d+[\\.,]?\\d*$"))
                throw new Exception("Budget is not a number, please try again");
            var answer = await client.PutAsync(_url + "Update", new StringContent(JsonConvert.SerializeObject(new Locality(loc)), Encoding.Default, "application/json-patch+json"));
            if (answer.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            throw new Exception(answer.ReasonPhrase);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocality(int id)
        {
            var answer = await client.DeleteAsync(_url + "Delete/" + id);
            return RedirectToAction("Index");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     ViewBag.ErrorText = null;
        //     return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string text=null)
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorText = text
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(HttpStatusCode code, string text = null)
        {
            return View(new ErrorViewModel
            {
                RequestId = code.ToString(),
                ErrorText = text
            });
        }
    }
}