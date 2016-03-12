using System;

namespace NiquIoC
{
    internal class RegisterTypeInfo
    {
        public RegisterTypeInfo(bool isSingleton, Type returnType, object instance)
        {
            IsSingleton = isSingleton;
            ReturnType = returnType;
            Instance = instance;
        }

        public bool IsSingleton { get; }

        public Type ReturnType { get; }

        public object Instance { get; set; }
    }
}