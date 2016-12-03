using System;

namespace NiquIoC.Interfaces
{
    public interface IContainerMember
    {
        void AsSingleton();

        void AsTransient();

        void AsPerThread();

        void AsPerHttpContext();

        void AsCustomObjectLifetimeManager(IObjectLifetimeManager objectLifetimeManager);
    }
}