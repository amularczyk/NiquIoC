using System.Web.Mvc;
using DryIoc;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class DryIocController : Controller
    {
        public ActionResult Resolve<T>(Container c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}