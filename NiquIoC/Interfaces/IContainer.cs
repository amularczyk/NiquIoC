using System;
using NiquIoC.Enums;

namespace NiquIoC.Interfaces
{
    public interface IContainer
    {
        IContainerMember RegisterType<T>()
            where T : class;
        
        IContainerMember RegisterType<TFrom, TTo>()
            where TTo : TFrom;
        
        IContainerMember RegisterType<T>(Func<object> objectFactory)
            where T : class;
        
        IContainerMember RegisterInstance<T>(T instance);
        
        T Resolve<T>(ResolveKind resolveKind);
        
        void BuildUp<T>(T instance, ResolveKind resolveKind);
    }
}