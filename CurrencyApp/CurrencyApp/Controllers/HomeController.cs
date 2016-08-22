using System;
using System.Linq;
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

        public JsonResult GetExchangeRateDifferences(DateTime date)
        {
            var exchangeRateService = CurrencyAppInjectionKernel.Instance.Get<IExchangeRatesService>();
            var yesterdayExchangeRates = exchangeRateService.Get(date.AddDays(-1));
            var todayExchangeRates = exchangeRateService.Get(date);

            if (yesterdayExchangeRates == null || todayExchangeRates == null)
            {
                return new JsonResult() { Data = new JsonData() { Success = false }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            var exchangeRateDifferences = todayExchangeRates.Select(todayRate => new ExchangeRateDifferenceViewModel(
                yesterdayExchangeRates.SingleOrDefault(yesterdayRate => yesterdayRate.Name == todayRate.Name), todayRate))
                .Where(item => item.RateDifference != 0)
                .OrderByDescending(item => item.RateDifference);
            
            return new JsonResult() {Data = new JsonData() {Data = exchangeRateDifferences }, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}