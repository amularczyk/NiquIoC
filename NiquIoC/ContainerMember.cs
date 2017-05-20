using System;
using System.Collections.Generic;
using System.Reflection;
using NiquIoC.Interfaces;
using NiquIoC.ObjectLifetimeManagers;

namespace NiquIoC
{
    internal class ContainerMember : IContainerMemberPrivate
    {
        public ContainerMember(IObjectLifetimeManager objectLifetimeManager)
        {
            ObjectLifetimeManager = objectLifetimeManager;
            ShouldCreateCache = true;
        }

        internal ConstructorInfo Constructor { get; set; }

        internal List<ParameterInfo> Parameters { get; set; }

        internal List<PropertyInfo> PropertiesInfo { get; set; }

        internal List<MethodInfo> MethodsInfo { get; set; }

        internal bool? IsCycleInConstructor { get; set; }

        internal bool ShouldCreateCache { get; set; }

        #region IContainerMemberPrivate

        public Type RegisteredType { get; set; }

        public Type ReturnType { get; set; }

        public IObjectLifetimeManager ObjectLifetimeManager { get; private set; }

        #endregion IContainerMemberPrivate

        #region IContainerMember

        public void AsSingleton()
        {
            AsCustomObjectLifetimeManager(new SingletonObjectLifetimeManager());
        }

        public void AsTransient()
        {
            AsCustomObjectLifetimeManager(new TransientObjectLifetimeManager());
        }

        public void AsPerThread()
        {
            AsCustomObjectLifetimeManager(new ThreadObjectLifetimeManager());
        }

        public void AsPerHttpContext()
        {
            AsCustomObjectLifetimeManager(new HttpContextObjectLifetimeManager());
        }

        public void AsCustomObjectLifetimeManager(IObjectLifetimeManager objectLifetimeManager)
        {
            if (!ShouldCreateCache && objectLifetimeManager.ObjectFactory == null)
                objectLifetimeManager.ObjectFactory = ObjectLifetimeManager.ObjectFactory;

            ObjectLifetimeManager = objectLifetimeManager;
        }

        #endregion IContainerMember
    }
}