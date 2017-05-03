using System.Web;
using System.Web.Mvc;

namespace NiquIoC.Test.WebApplication
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}