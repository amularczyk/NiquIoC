using System;

namespace NiquIoC.Exceptions
{
    public class WrongInterfaceRegistrationException : Exception
    {
        public WrongInterfaceRegistrationException(Type type)
        {
            _type = type;
        }

        private readonly Type _type;

        public override string Message => $"For interface type {_type.FullName} you must specify a class which implements it.";
    }
}