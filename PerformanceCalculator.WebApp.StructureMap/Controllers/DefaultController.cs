using System.Web.Mvc;
using StructureMap;

namespace PerformanceCalculator.WebApp.StructureMap.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(Container c)
        {
            var obj = c.GetInstance<T>();
            return View(obj);
        }
    }
}