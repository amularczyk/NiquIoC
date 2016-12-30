using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class UnityController : Controller
    {
        public ActionResult Resolve<T>(UnityContainer c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}