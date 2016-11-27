using System;

namespace NiquIoC.Interfaces
{
    internal interface IResolve //ToDo: Change to Resolver
    {
        object Resolve(ContainerMember containerMember, Action<object, ContainerMember> afterObjectCreate);
        void ClearCache(Type type);
    }
}