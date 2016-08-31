using System;

namespace NiquIoC.Interfaces
{
    public interface IContainerMember
    {
        void AsSingleton();

        void AsTransient();

        void AsCustomObjectLifetimeManager(IObjectLifetimeManager objectLifetimeManager);

        Type RegisteredType { get; }

        Type ReturnType { get; }
    }
}