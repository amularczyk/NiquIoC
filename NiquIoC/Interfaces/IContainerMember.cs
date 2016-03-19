using System;

namespace NiquIoC.Interfaces
{
    public interface IContainerMember
    {
        void AsSingleton();

        void AsTransient();

        bool IsSingleton { get; }

        Type RegisteredType { get; }

        Type ReturnType { get; }
    }
}