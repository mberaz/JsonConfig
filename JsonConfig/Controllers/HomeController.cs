using Configuration;
using System.Web.Mvc;

namespace JsonConfig.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var webconfig = Cunfiguration.WebConfiguration;
            var dataCOnfig = Cunfiguration.DataConfiguration;
            return View();
        }


    }
}