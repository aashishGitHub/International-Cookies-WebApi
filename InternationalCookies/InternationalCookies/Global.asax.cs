using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ApplicationServices;
using InternationalCookies.DataAccess;
using InternationalCookies.Domain;

namespace InternationalCookies
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CookiesRepositoryConfiguration.Initialise();
            CookiesDomainConfiguration.Initialise();
            CookieApplicationConfiguration.Initialise();
        }
    }
}
