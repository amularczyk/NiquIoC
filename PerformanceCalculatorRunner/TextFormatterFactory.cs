using System;
using PerformanceCalculatorRunner.Interfaces;
using PerformanceCalculatorRunner.Models;
using PerformanceCalculatorRunner.Writers;

namespace PerformanceCalculatorRunner
{
    public static class TextFormatterFactory
    {
        public static ITextFormatter GetTextFormatter(WriteKind writeKind)
        {
            switch (writeKind)
            {
                case WriteKind.Both:
                    return new CsvRegisterAndResolveTextFormatter();

                case WriteKind.Register:
                    return new CsvRegisterTextFormatter();

                case WriteKind.Resolve:
                    return new CsvResolveTextFormatter();

                default:
                    throw new ArgumentOutOfRangeException(nameof(writeKind), writeKind, null);
            }
        }
    }
}