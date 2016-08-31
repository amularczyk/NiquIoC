using System;
using System.Text;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class SingletonObjectLifetimeManager : IObjectLifetimeManager
    {
        private object _obj;

        public Func<object> ObjectFactory { get; set; }

        public object GetInstance()
        {
            if (_obj == null)
            {
                _obj = ObjectFactory();
            }

            return _obj;
        }
    }
}