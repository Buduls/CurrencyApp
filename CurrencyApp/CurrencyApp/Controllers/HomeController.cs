using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Business;
using Business.Services;
using CurrencyApp.Helpers;
using CurrencyApp.Models;
using Ninject;

namespace CurrencyApp.Controllers
{
    public class HomeController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var Request = requestContext.HttpContext.Request;

            ViewBag.BaseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                Request.ApplicationPath.TrimEnd('/') + "/";
            base.Initialize(requestContext);
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