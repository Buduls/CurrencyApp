using Business.DataManagers;
using Business.Services;
using Ninject;

namespace Business
{
    public class CurrencyAppInjectionKernel : StandardKernel
    {
        private static CurrencyAppInjectionKernel _kernel;
        private static readonly object ObjSync = new object();

        public static CurrencyAppInjectionKernel Instance
        {
            get
            {
                if (_kernel == null)
                {
                    lock (ObjSync)
                    {
                        if (_kernel == null)
                            _kernel = new CurrencyAppInjectionKernel();
                    }
                }

                return _kernel;
            }
        }

        private CurrencyAppInjectionKernel()
        {
            Bind<IExchangeRatesDataManager>().ToConstructor(ctorArg => new LbExchangeRatesDataManager());
            Bind<IExchangeRatesService>().ToConstructor(ctorArg => new CurrencyAppExchangeRatesService(ctorArg.Inject<IExchangeRatesDataManager>()));
        }
    }
}
