using System;

namespace NiquIoC.Exceptions
{
    public class NoProperConstructorException : Exception
    {
        public override string Message => "Lack of proper constructor. There should be only one constructor with attribute DependencyConstrutor or with max number of parameters.";
    }
}