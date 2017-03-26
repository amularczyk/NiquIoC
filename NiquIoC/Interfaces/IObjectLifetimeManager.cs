using System;

namespace NiquIoC.Interfaces
{
    public interface IObjectLifetimeManager
    {
        Func<object> ObjectFactory { get; set; }

        object GetInstance();
    }
}