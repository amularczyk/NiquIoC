using System;

namespace NiquIoC.Interfaces
{
    internal interface IResolve
    {
        object Resolve(ContainerMember containerMember, Action<object> afterObjectCreate);
        void ClearCache(Type type);
    }
}