using System;

namespace NiquIoC.Exceptions
{
    public class NoProperConstructorException : Exception
    {
        public NoProperConstructorException(Type type)
        {
            _type = type;
        }

        private readonly Type _type;
        public override string Message => $"Lack of proper constructor for type {_type}. There should be only one constructor with attribute DependencyConstrutor or with max number of parameters.";
    }
}