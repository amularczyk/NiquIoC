using System.Web.Mvc;
using Autofac;
using Autofac.Core;

namespace PerformanceCalculator.Tests.WebApp.Controllers
{
    public class AutofacController : Controller
    {
        public ActionResult Resolve<T>(Container c)
        {
            var obj = c.Resolve<T>();
            return View(obj);
        }
    }
}