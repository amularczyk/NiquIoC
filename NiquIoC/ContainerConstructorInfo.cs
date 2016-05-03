using System.Collections.Generic;
using System.Reflection;

namespace NiquIoC
{
    public class ContainerConstructorInfo
    {
        public ContainerConstructorInfo(ConstructorInfo constructor, IList<ParameterInfo> parameters)
        {
            Constructor = constructor;
            Parameters = parameters;
        }

        public ConstructorInfo Constructor { get; set; }

        public IList<ParameterInfo> Parameters { get; set; }
    }
}