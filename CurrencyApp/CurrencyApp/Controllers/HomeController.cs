﻿using System;
using System.Web.Mvc;
using Business.Services;
using CurrencyApp.Helpers;
using CurrencyApp.Models;

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
            var exchangeRateService = new LbExchangeRatesService(); //TODO: use injection
            var currencies = exchangeRateService.Get(date);

            if (currencies == null)
            {
                return new JsonResult() {Data = new JsonData() {Success = false}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
            return new JsonResult() {Data = new JsonData() {Data = currencies}, JsonRequestBehavior = JsonRequestBehavior.AllowGet}; //TODO: Move the AllowGet to an upper level
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

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}