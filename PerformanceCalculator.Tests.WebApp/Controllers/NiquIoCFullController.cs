using System.Web.Mvc;
using NiquIoC;
using NiquIoC.Enums;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class NiquIoCFullController : Controller
    {
        public ActionResult Resolve<T>(Container c)
        {
            var obj = c.Resolve<T>(ResolveKind.FullEmitFunction);
            return View(obj);
        }
    }
}