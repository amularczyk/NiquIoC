using System;

namespace NiquIoC.Exceptions
{
    public class TypeNotRegisteredException : Exception
    {
        private readonly Type _type;

        public TypeNotRegisteredException(Type type)
        {
            _type = type;
        }

        public override string Message => $"Type {_type.FullName} has not been registered.";
    }
}