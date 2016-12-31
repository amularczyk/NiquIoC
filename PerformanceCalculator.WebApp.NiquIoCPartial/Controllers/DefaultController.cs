using System.Web.Mvc;
using NiquIoC;
using NiquIoC.Enums;

namespace PerformanceCalculator.WebApp.NiquIoCPartial.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(Container c)
        {
            var obj = c.Resolve<T>(ResolveKind.PartialEmitFunction);
            return View(obj);
        }
    }
}