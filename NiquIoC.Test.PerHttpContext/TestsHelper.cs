using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using NiquIoC.Enums;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext
{
    public static class TestsHelper
    {
        public static T ResolveObject<T>(Container c, ResolveKind resolveKind)
        {
            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));

            var result = controller.ResolveObject<T>(c, resolveKind);

            return (T)((ViewResult)result).Model;
        }

        public static Tuple<T, T> ResolveObjects<T>(Container c, ResolveKind resolveKind)
        {
            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));

            var result1 = controller.ResolveObject<T>(c, resolveKind);
            var obj1 = (T)((ViewResult)result1).Model;

            var result2 = controller.ResolveObject<T>(c, resolveKind);
            var obj2 = (T)((ViewResult)result2).Model;

            return Tuple.Create(obj1, obj2);
        }

        public static T BuildUpObject<T>(Container c, T obj, ResolveKind resolveKind)
        {
            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            
            var result = controller.BuildUpObject(c, obj, resolveKind);

            return (T)((ViewResult)result).Model;
        }
    }
}