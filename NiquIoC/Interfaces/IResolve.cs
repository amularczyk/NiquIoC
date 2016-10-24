using System;

namespace NiquIoC.Interfaces
{
    internal interface IResolve //ToDo: Name
    {
        object Resolve(ContainerMember containerMember, Action<object, ContainerMember> afterObjectCreate);
        void ClearCache(Type type);
    }
}