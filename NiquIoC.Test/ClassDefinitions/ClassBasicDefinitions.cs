namespace NiquIoC.Test.ClassDefinitions
{
    internal interface IEmptyClass
    {
    }

    internal class EmptyClass : IEmptyClass
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

    internal interface ISampleClassWithInterfaceAsParameter
    {
        IEmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithInterfaceAsParameter : ISampleClassWithInterfaceAsParameter
    {
        public SampleClassWithInterfaceAsParameter(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public IEmptyClass EmptyClass { get; }
    }

    internal class SampleClassOther : ISampleClass
    {
        public SampleClassOther(EmptyClass emptyClass)
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
        public FirstClassWithCycleInConstructor(SecondClassWithCycleInConstructor secondClass)
        {
            SecondClass = secondClass;
        }

        public SecondClassWithCycleInConstructor SecondClass { get; private set; }
    }

    internal class SecondClassWithCycleInConstructor
    {
        public SecondClassWithCycleInConstructor(FirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public FirstClassWithCycleInConstructor FirstClass { get; private set; }
    }

    internal interface IFirstClassWithCycleInConstructor
    {
        ISecondClassWithCycleInConstructor SecondClass { get; }
    }

    internal class FirstClassWithCycleInConstructorInRegisteredType : IFirstClassWithCycleInConstructor
    {
        public FirstClassWithCycleInConstructorInRegisteredType(ISecondClassWithCycleInConstructor secondClass)
        {
            SecondClass = secondClass;
        }

        public ISecondClassWithCycleInConstructor SecondClass { get; private set; }
    }

    internal interface ISecondClassWithCycleInConstructor
    {
        IFirstClassWithCycleInConstructor FirstClass { get; }
    }

    internal class SecondClassWithCycleInConstructorInRegisteredType : ISecondClassWithCycleInConstructor
    {
        public SecondClassWithCycleInConstructorInRegisteredType(IFirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public IFirstClassWithCycleInConstructor FirstClass { get; private set; }
    }

    internal interface IClassWithCycleInConstructor
    {
        FirstClassWithCycleInConstructor FirstClass { get; }
    }

    internal class ClassWithCycleInConstructorInRegisteredType : IClassWithCycleInConstructor
    {
        public ClassWithCycleInConstructorInRegisteredType(FirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public FirstClassWithCycleInConstructor FirstClass { get; private set; }
    }

    internal interface IInterfaceWithCycleInConstructor
    {
        IFirstClassWithCycleInConstructor FirstClass { get; }
    }

    internal class InterfaceWithCycleInConstructorInRegisteredType : IInterfaceWithCycleInConstructor
    {
        public InterfaceWithCycleInConstructorInRegisteredType(IFirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public IFirstClassWithCycleInConstructor FirstClass { get; private set; }
    }
}