using System;
using NiquIoC.Enums;

namespace NiquIoC.Interfaces
{
    public interface IContainer
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IContainerMember RegisterType<T>()
            where T : class;

        /// <summary>
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        IContainerMember RegisterType<TFrom, TTo>()
            where TTo : TFrom;

        /// <summary>
        ///     By default objectFactory is registered as transient.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectFactory"></param>
        /// <returns></returns>
        IContainerMember RegisterType<T>(Func<object> objectFactory)
            where T : class;

        /// <summary>
        ///     By default instance is registered as singleton.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        IContainerMember RegisterInstance<T>(T instance);

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>(ResolveKind resolveKind);

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void BuildUp<T>(T instance, ResolveKind resolveKind);
    }
}