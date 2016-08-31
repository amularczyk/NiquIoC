using System;

namespace NiquIoC.Interfaces
{
    public interface IObjectLifetimeManager
    {
        object GetInstance();
        Func<object> ObjectFactory { get; set; }
    }
}