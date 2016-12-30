using System.Web.Mvc;
using Castle.Windsor;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class WindsorController : Controller
    {
        public ActionResult Resolve<T>(WindsorContainer c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}