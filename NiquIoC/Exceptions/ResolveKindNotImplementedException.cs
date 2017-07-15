using System;
using NiquIoC.Enums;

namespace NiquIoC.Exceptions
{
    public class ResolveKindNotImplementedException : Exception
    {
        private readonly ResolveKind _resolveKind;

        public ResolveKindNotImplementedException(ResolveKind resolveKind)
        {
            _resolveKind = resolveKind;
        }

        public override string Message => $"ResolveKind {_resolveKind} is not implemented.";
    }
}