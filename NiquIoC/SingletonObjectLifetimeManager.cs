using System;
using System.Text;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class SingletonObjectLifetimeManager : IObjectLifetimeManager
    {
        private object _instance;
        private object _obj;

        public SingletonObjectLifetimeManager()
        {
            _obj = new object();
        }

        public Func<object> ObjectFactory { get; set; }

        public object GetInstance()
        {
            if (_instance == null)
            {
                lock (_obj)
                {
                    if (_instance == null)
                    {
                        _instance = ObjectFactory();
                    }
                }
            }

            return _instance;
        }
    }
}