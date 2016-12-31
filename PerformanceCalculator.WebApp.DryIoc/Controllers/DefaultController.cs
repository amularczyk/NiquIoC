using System.Web.Mvc;
using DryIoc;

namespace PerformanceCalculator.WebApp.DryIoc.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Resolve<T>(Container c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}