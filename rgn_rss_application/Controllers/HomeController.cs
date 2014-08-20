using System.Web.Mvc;
using RssReader.Domain.Repositories;

namespace rgn_rss_application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFeeds()
        {
            var reader = new RssReaderRepository();
            var result = reader.ReadFeed("http://www.theverge.com/rss/frontpage");
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}