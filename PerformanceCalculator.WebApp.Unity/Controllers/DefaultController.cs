using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace PerformanceCalculator.WebApp.Unity.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(UnityContainer c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}