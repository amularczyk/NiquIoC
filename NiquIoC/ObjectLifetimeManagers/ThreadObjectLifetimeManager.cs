using System;
using System.Collections.Generic;
using System.Threading;
using NiquIoC.Interfaces;

namespace NiquIoC.ObjectLifetimeManagers
{
    public class ThreadObjectLifetimeManager : IObjectLifetimeManager
    {
        private readonly Dictionary<Thread, object> _instancePerThreadCache;
        private readonly object _obj;

        public ThreadObjectLifetimeManager()
        {
            _instancePerThreadCache = new Dictionary<Thread, object>();
            _obj = new object();
        }

        public Func<object> ObjectFactory { get; set; }

        public object GetInstance()
        {
            var thread = Thread.CurrentThread;
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_instancePerThreadCache.ContainsKey(thread))
            {
                lock (_obj)
                {
                    if (!_instancePerThreadCache.ContainsKey(thread))
                    {
                        _instancePerThreadCache[thread] = ObjectFactory();
                    }
                }
            }

            // ReSharper disable once InconsistentlySynchronizedField
            return _instancePerThreadCache[thread];
        }
    }
}