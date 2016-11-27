using System;

namespace NiquIoC.Exceptions
{
    public class HttpContextNoSetException : Exception
    {
        public override string Message => "HttpContext is not set. Are you sure that you want registered object per HttpContext?";
    }
}