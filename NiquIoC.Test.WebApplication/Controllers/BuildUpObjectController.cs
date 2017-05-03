using System.Web.Http;
using NiquIoC.Enums;

namespace NiquIoC.Test.WebApplication.Controllers
{
    public class BuildUpObjectController : ApiController
    {
        public object Get<T>(Container c, T obj, ResolveKind resolveKind)
        {
            c.BuildUp(obj, resolveKind);
            return obj;
        }
    }
}