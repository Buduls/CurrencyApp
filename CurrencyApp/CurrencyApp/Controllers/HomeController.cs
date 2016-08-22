using System;
using System.Web.Mvc;
using Business;
using Business.Services;
using CurrencyApp.Helpers;
using CurrencyApp.Models;
using Ninject;

namespace CurrencyApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetResult(DateTime date)
        {
            var exchangeRateService = CurrencyAppInjectionKernel.Instance.Get<IExchangeRatesService>();
            var currencies = exchangeRateService.Get(date);

            if (currencies == null)
            {
                return new JsonResult() {Data = new JsonData() {Success = false}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
            return new JsonResult() {Data = new JsonData() {Data = currencies}, JsonRequestBehavior = JsonRequestBehavior.AllowGet}; //TODO: Move the AllowGet to an upper level
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}