using System;

namespace NiquIoC.Attributes
{
    [AttributeUsage(System.AttributeTargets.Constructor, AllowMultiple = false)]
    public class DependencyConstrutor : Attribute
    {
    }
}