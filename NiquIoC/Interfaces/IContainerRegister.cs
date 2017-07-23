using System;

namespace NiquIoC.Interfaces
{
    public interface IContainerRegister
    {
        IContainerMember RegisterType<T>()
            where T : class;

        IContainerMember RegisterType(Type type);

        IContainerMember RegisterType<TFrom, TTo>()
            where TTo : TFrom;

        IContainerMember RegisterType(Type typeFrom, Type typeTo);

        IContainerMember RegisterType<T>(Func<IContainerResolve, T> objectFactory)
            where T : class;

        IContainerMember RegisterType(Type type, Func<IContainerResolve, object> objectFactory);

        IContainerMember RegisterInstance<T>(T instance);
    }
}