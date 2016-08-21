using System;
using System.Collections.Generic;
using System.Linq;
using Business.DataManagers;
using Business.Dto;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Business.Test
{
    [TestClass]
    public class EchangeRatesServiceTests
    {
        [TestMethod]
        public void Get_ReturnNullIfFailed()
        {
            var exchangeRatesService = GetService();
            var result = exchangeRatesService.Get(new DateTime(1990, 1, 1));

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_ReturnObjectIfDateValid()
        {
            var exchangeRatesService = GetService();
            var result = exchangeRatesService.Get(new DateTime(2000, 1, 1));

           
            Assert.IsTrue(result.SequenceEqual(new List<ExchangeRateDto>()));
        }

        private CurrencyAppExchangeRatesService GetService()
        {
            var fakeExchangeRatesDataManager = Substitute.For<IExchangeRatesDataManager>();

            fakeExchangeRatesDataManager.Get(Arg.Any<DateTime>()).ReturnsNull();


            fakeExchangeRatesDataManager.Get(Arg.Is<DateTime>(argument =>
                argument >= new DateTime(1993, 06, 25) &&
                argument < new DateTime(2014, 01, 01))).Returns(new List<ExchangeRate>());
            
            var exchangeRatesService = new CurrencyAppExchangeRatesService(fakeExchangeRatesDataManager);
            return exchangeRatesService;
        }
    }
}
