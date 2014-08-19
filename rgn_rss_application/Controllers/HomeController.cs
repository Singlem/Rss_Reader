using System.Web.Mvc;

namespace rgn_rss_application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}