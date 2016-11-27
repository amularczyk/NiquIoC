using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using NiquIoC.Exceptions;
using NiquIoC.Interfaces;

namespace NiquIoC.ObjectLifetimeManagers
{
    public class HttpContextObjectLifetimeManager : IObjectLifetimeManager
    {
        private readonly Dictionary<HttpContext, object> _instancePerHttpContextCache;
        private readonly object _obj;

        public HttpContextObjectLifetimeManager()
        {
            _instancePerHttpContextCache = new Dictionary<HttpContext, object>();
            _obj = new object();
        }

        public Func<object> ObjectFactory { get; set; }

        public object GetInstance()
        {
            var httpContext = HttpContext.Current; //TODO: Change on HttpContextBase?
            if (httpContext == null)
            {
                throw new HttpContextNoSetException();
            }

            // ReSharper disable once InconsistentlySynchronizedField
            if (!_instancePerHttpContextCache.ContainsKey(httpContext))
            {
                lock (_obj)
                {
                    if (!_instancePerHttpContextCache.ContainsKey(httpContext))
                    {
                        _instancePerHttpContextCache[httpContext] = ObjectFactory();
                    }
                }
            }

            // ReSharper disable once InconsistentlySynchronizedField
            return _instancePerHttpContextCache[httpContext];
        }
    }
}