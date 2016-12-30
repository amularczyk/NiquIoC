using System.Web.Mvc;
using LightInject;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class LightInjectController : Controller
    {
        public ActionResult Resolve<T>(ServiceContainer c)
        {
            var obj = c.GetInstance<T>();
            return View(obj);
        }
    }
}