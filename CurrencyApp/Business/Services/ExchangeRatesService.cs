using System;
using System.Collections.Generic;
using System.Linq;
using Business.DataManagers;
using Business.Dto;

namespace Business.Services
{
    public interface IExchangeRatesService
    {
        IEnumerable<ExchangeRateDto> Get(DateTime date);
    }

    public class CurrencyAppExchangeRatesService : IExchangeRatesService
    {
        private readonly IExchangeRatesDataManager _exchangeRatesDataManager;

        public CurrencyAppExchangeRatesService(IExchangeRatesDataManager exchangeRatesDataManager)
        {
            _exchangeRatesDataManager = exchangeRatesDataManager;
        }

        public IEnumerable<ExchangeRateDto> Get(DateTime date)
        {
            var exchangeRates = _exchangeRatesDataManager.Get(date);

            if (exchangeRates == null)
            {
                return null;
            }

            var exchangeRateDtos = exchangeRates.Select(item => new ExchangeRateDto() { Name = item.Currency, Rate = item.Rate, Quantity = item.Quantity});
            
            return exchangeRateDtos;
        }
    }
}
