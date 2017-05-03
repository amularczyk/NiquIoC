using System.Web.Http;
using NiquIoC.Enums;

namespace NiquIoC.Test.WebApplication.Controllers
{
    public class ResolveObjectController : ApiController
    {
        public object Get<T>(Container c, ResolveKind resolveKind)
        {
            var obj = c.Resolve<T>(resolveKind);
            return obj;
        }
    }
}