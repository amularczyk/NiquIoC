using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NiquIoC.Interfaces;

namespace NiquIoC.ObjectLifetimeManagers
{
    public class ThreadObjectLifetimeManager : IObjectLifetimeManager
    {
        private readonly Dictionary<Thread, object> _instancePerThreadCache;

        public ThreadObjectLifetimeManager()
        {
            _instancePerThreadCache = new Dictionary<Thread, object>();
        }

        public Func<object> ObjectFactory { get; set; }

        public object GetInstance()
        {
            var thread = Thread.CurrentThread;
            if (!_instancePerThreadCache.ContainsKey(thread))
            {
                _instancePerThreadCache[thread] = ObjectFactory();
            }

            return _instancePerThreadCache[thread];
        }
    }
}
