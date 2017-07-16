using NiquIoC.Enums;

namespace NiquIoC.Interfaces
{
    public interface IContainerBuildUp
    {
        void BuildUp<T>(T instance);

        void BuildUp<T>(T instance, ResolveKind resolveKind);
    }
}