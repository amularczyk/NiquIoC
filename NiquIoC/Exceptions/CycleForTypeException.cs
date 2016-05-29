using System;

namespace NiquIoC.Exceptions
{
    public class CycleForTypeException : Exception
    {
        public CycleForTypeException(Type type)
        {
            _type = type;
        }

        private readonly Type _type;

        public override string Message => $"Appeared cycle when resolving constructor for object of type {_type.FullName}.";
    }
}