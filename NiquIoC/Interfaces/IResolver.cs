using System;

namespace NiquIoC.Interfaces
{
    internal interface IResolver
    {
        object Resolve(ContainerMember containerMember, Action<object, ContainerMember> afterObjectCreate);

        void ClearCache(Type type);
    }
}