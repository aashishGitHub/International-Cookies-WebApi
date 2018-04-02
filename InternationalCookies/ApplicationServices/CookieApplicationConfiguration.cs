using ApplicationServices.Interfaces;
using CookiesBootstrapper;
using Unity;

namespace ApplicationServices
{
    public static class CookieApplicationConfiguration
    {
        private static bool _initialised;
        public static void Initialise()
        {
            if (_initialised) return;

            CookiesUnityContainer.Current.RegisterType<ICustomerService, CustomerService>()
                .RegisterType<IProductService, ProductService>()
                .RegisterType<IOrderService, OrderService>();

            _initialised = true;
        }
    }
}
