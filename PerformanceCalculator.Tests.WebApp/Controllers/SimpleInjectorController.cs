using System.Web.Mvc;
using SimpleInjector;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class SimpleInjectorController : Controller
    {
        public ActionResult Resolve<T>(Container c)
             where T : class
        {
            var obj = c.GetInstance<T>();
            return View(obj);
        }
    }
}