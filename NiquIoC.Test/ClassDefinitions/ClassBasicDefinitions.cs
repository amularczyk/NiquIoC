using NiquIoC.Attributes;

namespace NiquIoC.Test
{
    internal class EmptyClass
    {
    }

    internal interface ISampleClass
    {
        EmptyClass EmptyClass { get; }
    }

    internal class SampleClass : ISampleClass
    {
        public SampleClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public EmptyClass EmptyClass { get; }
    }
    
    internal class SampleClassWithSimpleType
    {
        public SampleClassWithSimpleType(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }

    internal class FirstClassWithCycleInConstructor
    {
        public FirstClassWithCycleInConstructor(SecondClassWithCycleInConstructor secondClassWith)
        {
            SecondClassWith = secondClassWith;
        }

        public SecondClassWithCycleInConstructor SecondClassWith { get; private set; }
    }

    internal class SecondClassWithCycleInConstructor
    {
        public SecondClassWithCycleInConstructor(FirstClassWithCycleInConstructor firstClassWith)
        {
            FirstClassWith = firstClassWith;
        }

        public FirstClassWithCycleInConstructor FirstClassWith { get; private set; }
    }
}