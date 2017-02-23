using System;
using System.Web.Mvc;
using NiquIoC.Enums;

namespace NiquIoC.Test.WebApplication.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult ResolveObject<T>(Container c, ResolveKind resolveKind)
        {
            var obj = c.Resolve<T>(resolveKind);
            return View(obj);
        }

        public ActionResult BuildUpObject<T>(Container c, T obj, ResolveKind resolveKind)
        {
            c.BuildUp(obj, resolveKind);
            return View(obj);
        }
    }
}