using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;
using Business.LbExchangeRates;

namespace Business.DataManagers
{
    public interface IExchangeRatesDataManager
    {
        IEnumerable<ExchangeRate> Get(DateTime date);
    }

    public abstract class ExchangeRate
    {
        [XmlIgnore]
        public virtual string Date { get; set; }
        [XmlIgnore]
        public virtual string Currency { get; set; }
        [XmlIgnore]
        public virtual string Quantity { get; set; }
        [XmlIgnore]
        public virtual decimal Rate { get; set; }
    }

    public class LbExchangeRatesDataManager : IExchangeRatesDataManager
    {
        private const string ServiceUrl = "http://www.lb.lt/webservices/ExchangeRates/ExchangeRates.asmx"; // This can be moved to a .config in case deployments are done rarely

        public IEnumerable<ExchangeRate> Get(DateTime date)
        {
            var lbExchangeRatesClient = GetLbWebServiceConnection();
            var exchangeRatesXml = lbExchangeRatesClient.getExchangeRatesByDate(date.ToString("yyyy-MM-dd"));

            LbExchangeRateCollection lbExchangeRates;
            try
            {
                lbExchangeRates = DeserializeExchangeRates(exchangeRatesXml);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception); // This should be replaced with a log mechanism
                return null;
            }
            
            return lbExchangeRates.Items;
        }

        private LbExchangeRateCollection DeserializeExchangeRates(XmlNode xmlRoot)
        {
            var xmlReader = new XmlNodeReader(xmlRoot);
            var serializer = new XmlSerializer(typeof(LbExchangeRateCollection));
            var exchangeRates = serializer.Deserialize(xmlReader) as LbExchangeRateCollection;

            return exchangeRates;
        }

        private ExchangeRatesSoap GetLbWebServiceConnection()
        {
            EndpointAddress address = new EndpointAddress(ServiceUrl);
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);

            //TODO: setup necessary constraints

            var factory = new ChannelFactory<ExchangeRatesSoap>(binding, address);
            var service = factory.CreateChannel();

            return service;
        }

        [XmlRoot("ExchangeRates")]
        public class LbExchangeRateCollection
        {
            [XmlElement("item")]
            public LbExchangeRate[] Items { get; set; }
        }

        public class LbExchangeRate : ExchangeRate
        {
            [XmlElement("date")]
            public override string Date { get; set; }
            [XmlElement("currency")]
            public override string Currency { get; set; }
            [XmlElement("quantity")]
            public override string Quantity { get; set; }
            [XmlElement("rate")]
            public override decimal Rate { get; set; }
        }
    }
}
