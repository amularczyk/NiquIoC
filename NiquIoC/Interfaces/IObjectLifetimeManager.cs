using System;

namespace NiquIoC.Interfaces
{
    public interface IObjectLifetimeManager
    {
        bool IsObjectSetted { get; }
        void SetObject(Func<object> objFunc);
        object GetObject();
    }
}