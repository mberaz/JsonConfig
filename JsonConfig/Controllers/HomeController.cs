using Configuration;
using System.Web.Mvc;

namespace JsonConfig.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var config = Cunfiguration.WebConfiguration;
            return View();
        }


    }
}