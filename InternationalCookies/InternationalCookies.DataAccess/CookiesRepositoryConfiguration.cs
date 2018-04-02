using System.Data.Entity;
using CookiesBootstrapper;
using InternationalCookies.DataAccess.DbContext;
using InternationalCookies.DataAccess.Repositories;
using InternationalCookies.Domain.RepositoriesInterfaces;
using Unity;
using Unity.Lifetime;

namespace InternationalCookies.DataAccess
{
    public static class CookiesRepositoryConfiguration
    {
        private static bool _initialised;
        public static void Initialise()
        {
            if (_initialised) return;
            Database.SetInitializer<CookiesDbContext>(null);

            //TODO: Move the connection string reading logic via Configuration manager 
            CookiesUnityContainer.Current
                .RegisterInstance("CookiesDbContext",
                // @"data source=IN01LAP80005\DEV2008;initial catalog=InternationalCookies;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
                @"Server=intcookieserver1.database.windows.net;Initial Catalog=IntCookieDB1;Persist Security Info=False;User ID=Aashish;Password=Password.123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                .RegisterType<CookiesDbContext>(new PerResolveLifetimeManager())
                .RegisterType<ICustomerRepository, CustomerRepository>()
                .RegisterType<IOrderRepository, OrderRepository>()
                .RegisterType<IProductsRepository, ProductsRepository>()
                .RegisterType<IStockRepository, StockRepository>();
            
            _initialised = true;
        }
    }
}
