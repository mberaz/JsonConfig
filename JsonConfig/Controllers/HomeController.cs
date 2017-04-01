using Configuration;
using Configuration.Models;
using System.Web.Mvc;

namespace JsonConfig.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var webconfigdev =WebConfiguration.Instance().UserName;

            var webconfigprod = WebConfiguration.Instance("ProdUS").UserName;
            var webconfiglocal = WebConfiguration.Instance("Local").UserName;
            return View();
        }


    }
}