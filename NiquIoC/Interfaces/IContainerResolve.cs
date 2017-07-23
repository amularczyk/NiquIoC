using System;
using NiquIoC.Enums;

namespace NiquIoC.Interfaces
{
    public interface IContainerResolve
    {
        T Resolve<T>();

        T Resolve<T>(ResolveKind resolveKind);

        object Resolve(Type type);

        object Resolve(Type type, ResolveKind resolveKind);
    }
}