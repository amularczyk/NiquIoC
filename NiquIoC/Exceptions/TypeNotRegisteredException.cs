using System;

namespace NiquIoC.Exceptions
{
    public class TypeNotRegisteredException : Exception
    {
         public override string Message => "Type has not been registered.";
    }
}