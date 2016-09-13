using System;
using System.Text;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class SingletonObjectLifetimeManager : IObjectLifetimeManager
    {
        private object _instance;
        private Func<object> _objectFactory;
        
        public Func<object> ObjectFactory
        {
            get { return _objectFactory; }
            set
            {
                _objectFactory = value;
                _instance = _objectFactory();
            }
        }

        public object GetInstance()
        {
            return _instance;
        }
    }
}