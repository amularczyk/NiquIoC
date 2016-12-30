using System.Web.Mvc;
using StructureMap;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class StructureMapController : Controller
    {
        public ActionResult Resolve<T>(Container c)
        {
            var obj = c.GetInstance<T>();
            return View(obj);
        }
    }
}