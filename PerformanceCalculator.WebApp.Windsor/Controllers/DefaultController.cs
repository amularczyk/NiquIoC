using System.Web.Mvc;
using Castle.Windsor;

namespace PerformanceCalculator.WebApp.Windsor.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(WindsorContainer c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}