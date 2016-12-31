using System.Web.Mvc;
using LightInject;

namespace PerformanceCalculator.WebApp.LightInject.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(ServiceContainer c)
        {
            var obj = c.GetInstance<T>();
            return View(obj);
        }
    }
}