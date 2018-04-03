using System.Web.Mvc;

namespace InternationalCookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = Welcome to International Cookies";

            return View();
        }
    }
}
