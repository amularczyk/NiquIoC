using System;
using System.Collections.Generic;
using System.Reflection;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    internal class ContainerMember : IContainerMember
    {
        public ContainerMember()
        {
            IsSingleton = false;
        }

        public ContainerMember(object instance)
        {
            IsSingleton = true;
            Instance = instance;
        }

        public ContainerMember(Func<object> objectFactory)
        {
            IsSingleton = false;
            ObjectFactory = objectFactory;
        }

        public object Instance { get; set; }

        public Func<object> ObjectFactory { get; set; }

        public void AsSingleton()
        {
            IsSingleton = true;
        }

        public void AsTransient()
        {
            IsSingleton = false;
        }

        public bool IsSingleton { get; private set; }

        public Type RegisteredType { get; set; }

        public Type ReturnType { get; set; }

        internal ConstructorInfo Constructor { get; set; }

        internal List<ParameterInfo> Parameters { get; set; }

        internal List<PropertyInfo> PropertiesInfo { get; set; }

        internal List<MethodInfo> MethodsInfo { get; set; }

        internal bool? CycleInConstructor { get; set; }
    }
}