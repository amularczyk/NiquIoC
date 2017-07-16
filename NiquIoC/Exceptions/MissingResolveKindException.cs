using System;

namespace NiquIoC.Exceptions
{
    public class MissingResolveKindException : Exception
    {
        public override string Message => "You have to declare ResolveKind in constructor or use Resolve/BuildUp method with ResolveKind parameter.";
    }
}