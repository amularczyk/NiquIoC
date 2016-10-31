using System;
using System.Web.Mvc;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.WebApplication.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult EmptyClass(Container c)
        {
            var emptyClass = c.Resolve<EmptyClass>();
            return View(emptyClass);
        }

        public ActionResult SampleClass(Container c)
        {
            var sampleClass = c.Resolve<SampleClass>();
            return View(sampleClass);
        }

        public ActionResult TwoSampleClass(Container c)
        {
            var sampleClass1 = c.Resolve<SampleClass>();
            var sampleClass2 = c.Resolve<SampleClass>();
            return View(Tuple.Create(sampleClass1, sampleClass2));
        }
    }
}