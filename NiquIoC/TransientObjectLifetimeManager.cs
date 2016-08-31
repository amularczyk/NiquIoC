using System;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class TransientObjectLifetimeManager : IObjectLifetimeManager
    {
        private Func<object> _objFunc;
        public bool IsObjectSetted { get; private set; }

        public TransientObjectLifetimeManager()
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
            return _objFunc();
        }
    }
}