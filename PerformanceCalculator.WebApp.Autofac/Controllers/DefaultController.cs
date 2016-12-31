using System.Web.Mvc;
using Autofac;

namespace PerformanceCalculator.WebApp.Autofac.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(IContainer c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}