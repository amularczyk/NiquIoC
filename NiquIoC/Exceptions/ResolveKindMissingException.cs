using System;
using NiquIoC.Enums;

namespace NiquIoC.Exceptions
{
    public class ResolveKindMissingException : Exception
    {
        private readonly ResolveKind _resolveKind;

        public ResolveKindMissingException(ResolveKind resolveKind)
        {
            _resolveKind = resolveKind;
        }

        public override string Message => $"ResolveKind {_resolveKind} is not implemented.";
    }
}