using System;
using Business.Dto;

namespace CurrencyApp.Models
{
    public class ExchangeRateDifferenceViewModel
    {
        public ExchangeRateDifferenceViewModel(ExchangeRateDto yestardayExchangeRate, ExchangeRateDto todayExchangeRate)
        {
            Name = todayExchangeRate.Name;
            Quantity = todayExchangeRate.Quantity;
            RateDifference = Math.Round((todayExchangeRate.Rate / yestardayExchangeRate.Rate) - 1, 4, MidpointRounding.AwayFromZero);
        }

        public string Name { get; set; }
        public string Quantity { get; set; }
        public decimal RateDifference { get; set; }
    }
}