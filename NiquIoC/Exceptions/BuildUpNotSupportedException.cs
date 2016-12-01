using System;
using NiquIoC.Enums;

namespace NiquIoC.Exceptions
{
    public class BuildUpNotSupportedException : Exception
    {
        public BuildUpNotSupportedException(ResolveKind resolveKind)
        {
            _resolveKind = resolveKind;
        }

        private readonly ResolveKind _resolveKind;

        public override string Message => $"BuildUp is not supported for {_resolveKind}";
    }
}