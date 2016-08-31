using System;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class TransientObjectLifetimeManager : IObjectLifetimeManager
    {
        public Func<object> ObjectFactory { get; set; }

        public object GetInstance()
        {
            return ObjectFactory();
        }
    }
}