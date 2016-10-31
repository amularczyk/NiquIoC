using System;
using System.Web.Mvc;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.WebApplication.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult ResolveObject<T>(Container c, ResolveKind resolveKind)
        {
            var obj = c.Resolve<T>(resolveKind);
            return View(obj);
        }
    }
}