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
        public ActionResult IndexPlusPlus()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetExchangeRateDifferences(DateTime date)
        {
            var exchangeRateService = CurrencyAppInjectionKernel.Instance.Get<IExchangeRatesService>();
            var yesterdayExchangeRates = exchangeRateService.Get(date.AddDays(-1));
            var todayExchangeRates = exchangeRateService.Get(date);
            var returnObj = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            if (yesterdayExchangeRates == null || todayExchangeRates == null)
            {
                returnObj.Data = new JsonData() {Success = false};
                return returnObj;
            }

            var exchangeRateDifferences = todayExchangeRates.Select(todayRate => new ExchangeRateDifferenceViewModel(
                yesterdayExchangeRates.SingleOrDefault(yesterdayRate => yesterdayRate.Name == todayRate.Name), todayRate))
                .Where(item => item.RateDifference != 0)
                .OrderByDescending(item => item.RateDifference);

            returnObj.Data = new JsonData() { Data = exchangeRateDifferences };
            return returnObj;
        }
    }
}