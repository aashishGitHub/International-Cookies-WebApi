using CookiesBootstrapper;
using InternationalCookies.Domain.Interfaces;
using InternationalCookies.Domain.Service;
using Unity;

namespace InternationalCookies.Domain
{
    public static class CookiesDomainConfiguration
    {
        private static bool _initialised;
        public static void Initialise()
        {
            if (_initialised) return;
            
            CookiesUnityContainer.Current.RegisterType<ICustomerDomainService, CustomerService>()
                .RegisterType<IOrderDomainService, OrderDomainService>()
                .RegisterType<IProductDomainService, ProductDomainService>()
                .RegisterType<IStockDomainService, StockDomainService>();

            _initialised = true;
        }
    }
}
