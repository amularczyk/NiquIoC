namespace NiquIoC.Test.ClassDefinitions
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

    internal class SampleClassOther : ISampleClass
    {
        public SampleClassOther(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public EmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithInterface
    {
        public SampleClassWithInterface(ISampleClass sampleClass)
        {
            SampleClass = sampleClass;
        }

        public ISampleClass SampleClass { get; }
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

    internal interface IFirstClassWithCycleInConstructor
    {
        ISecondClassWithCycleInConstructor SecondClassWith { get; }
    }

    internal class FirstClassWithCycleInConstructorInRegisteredType : IFirstClassWithCycleInConstructor
    {
        public FirstClassWithCycleInConstructorInRegisteredType(ISecondClassWithCycleInConstructor secondClassWith)
        {
            SecondClassWith = secondClassWith;
        }

        public ISecondClassWithCycleInConstructor SecondClassWith { get; private set; }
    }

    internal interface ISecondClassWithCycleInConstructor
    {
        IFirstClassWithCycleInConstructor FirstClassWith { get; }
    }

    internal class SecondClassWithCycleInConstructorInRegisteredType : ISecondClassWithCycleInConstructor
    {
        public SecondClassWithCycleInConstructorInRegisteredType(IFirstClassWithCycleInConstructor firstClassWith)
        {
            FirstClassWith = firstClassWith;
        }

        public IFirstClassWithCycleInConstructor FirstClassWith { get; private set; }
    }
}