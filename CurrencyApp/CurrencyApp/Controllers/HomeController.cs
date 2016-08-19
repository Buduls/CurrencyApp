using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurrencyApp.Models;

namespace CurrencyApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetResult()
        {
            var currencies = new List<CurrencyViewModel>()
            {
                new CurrencyViewModel() { Name = "EUR", Rate = 1},
                new CurrencyViewModel() { Name = "PLN", Rate = 0.2584M},
                new CurrencyViewModel() { Name = "SEK", Rate = 0.1045M},
                new CurrencyViewModel() { Name = "NOK", Rate = 0.0951M},
                new CurrencyViewModel() { Name = "DKK", Rate = 0.1128M}
            };
            
            return new JsonResult() {Data = currencies, JsonRequestBehavior = JsonRequestBehavior.AllowGet}; //TODO: Move the AllowGet to an upper level
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}