using System;
using System.Collections.Generic;

namespace NiquIoC.Resolver
{
    internal class FullEmitFunctionResult
    {
        public Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object> Result { get; set; }
    }
}