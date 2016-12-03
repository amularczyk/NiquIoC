using System;

namespace NiquIoC.Interfaces
{
    public interface IContainerMemberPrivate : IContainerMember
    {
        Type RegisteredType { get; }

        Type ReturnType { get; }

        IObjectLifetimeManager ObjectLifetimeManager { get; }
    }
}