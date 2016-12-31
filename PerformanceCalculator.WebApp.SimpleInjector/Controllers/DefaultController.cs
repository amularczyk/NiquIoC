using System.Web.Mvc;
using SimpleInjector;

namespace PerformanceCalculator.WebApp.SimpleInjector.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(Container c)
             where T : class
        {
            var obj = c.GetInstance<T>();
            return View(obj);
        }
    }
}