using System;
using System.Collections.Generic;
using NiquIoC.Exceptions;

namespace NiquIoC.Extensions
{
    public static class DictionaryExtension
    {
        public static TValue GetValue<TValue>(this IReadOnlyDictionary<Type, TValue> dict, Type type)
            where TValue : class
        {
            try
            {
                return dict[type];
            }
            catch (KeyNotFoundException)
            {
                throw new TypeNotRegisteredException(type);
            }
        }
    }
}