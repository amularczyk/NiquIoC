using System;

namespace NiquIoC.Attributes
{
    [AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class DependencyProperty : Attribute
    {
    }
}