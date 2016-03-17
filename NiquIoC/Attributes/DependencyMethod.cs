using System;

namespace NiquIoC.Attributes
{
    [AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false)]
    public class DependencyMethod : Attribute
    {
    }
}