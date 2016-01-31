using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiquIoCWithFasterflect
{
    [System.AttributeUsage(System.AttributeTargets.Constructor, AllowMultiple = false)]
    public class DependencyConstrutor : System.Attribute
    {
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class DependencyProperty : System.Attribute
    {
    }
}
