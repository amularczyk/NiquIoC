using System;
using System.Collections.Generic;
using System.Reflection;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    internal class ContainerMember : IContainerMember
    {
        public ContainerMember(IObjectLifetimeManager objectLifetimeManager)
        {
            if (objectLifetimeManager == null)
                throw new ArgumentNullException(); //ToDo: Exception
            
            ObjectLifetimeManager = objectLifetimeManager;
            CreateCache = true;
        }

        public void AsSingleton()
        {
            AsCustomObjectLifetimeManager(new SingletonObjectLifetimeManager());
        }

        public void AsTransient()
        {
            AsCustomObjectLifetimeManager(new TransientObjectLifetimeManager());
        }

        public void AsCustomObjectLifetimeManager(IObjectLifetimeManager objectLifetimeManager)
        {
            if (!CreateCache && objectLifetimeManager.ObjectFactory == null)
            {
                objectLifetimeManager.ObjectFactory = ObjectLifetimeManager.ObjectFactory;
            }

            ObjectLifetimeManager = objectLifetimeManager;
        }

        public Type RegisteredType { get; set; }

        public Type ReturnType { get; set; }

        public IObjectLifetimeManager ObjectLifetimeManager { get; private set; }

        internal ConstructorInfo Constructor { get; set; }

        internal List<ParameterInfo> Parameters { get; set; }

        internal List<PropertyInfo> PropertiesInfo { get; set; }

        internal List<MethodInfo> MethodsInfo { get; set; }

        internal bool? CycleInConstructor { get; set; }

        internal bool CreateCache { get; set; }
    }
}