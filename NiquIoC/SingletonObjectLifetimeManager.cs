using System;
using System.Text;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class SingletonObjectLifetimeManager : IObjectLifetimeManager
    {
        private object _obj;
        private Func<object> _objFunc;
        public bool IsObjectSetted { get; private set; }

        public SingletonObjectLifetimeManager()
        {
            IsObjectSetted = false;
        }

        public void SetObject(Func<object> objFunc)
        {
            _objFunc = objFunc;
            IsObjectSetted = true;
        }

        public object GetObject()
        {
            if (_obj == null)
            {
                _obj = _objFunc();
            }

            return _obj;
        }
    }
}