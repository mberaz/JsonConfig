using Configuration;
using Configuration.Models;
using System.Web.Mvc;

namespace JsonConfig.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var webconfigdev =WebConfiguration.Insance().UserName;

            var webconfigprod = WebConfiguration.Insance("ProdUS").UserName;
            var webconfiglocal = WebConfiguration.Insance("Local").UserName;
            return View();
        }


    }
}