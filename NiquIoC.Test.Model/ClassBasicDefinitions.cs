namespace NiquIoC.Test.Model
{
    public interface IEmptyClass
    {
    }

    public class EmptyClass : IEmptyClass
    {
    }

    public interface ISampleClass
    {
        EmptyClass EmptyClass { get; }
    }

    public class SampleClass : ISampleClass
    {
        public SampleClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public EmptyClass EmptyClass { get; }
    }

    public interface ISampleClassWithInterfaceAsParameter
    {
        IEmptyClass EmptyClass { get; }
    }

    public class SampleClassWithInterfaceAsParameter : ISampleClassWithInterfaceAsParameter
    {
        public SampleClassWithInterfaceAsParameter(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public IEmptyClass EmptyClass { get; }
    }

    public class SampleClassOther : ISampleClass
    {
        public SampleClassOther(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public EmptyClass EmptyClass { get; }
    }

    public interface ISampleClassOtherWithInterfaceAsParameter
    {
        IEmptyClass EmptyClass { get; }
    }

    public class SampleClassOtherWithInterfaceAsParameter : ISampleClassOtherWithInterfaceAsParameter
    {
        public SampleClassOtherWithInterfaceAsParameter(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public IEmptyClass EmptyClass { get; }
    }

    public interface ISampleClassWithStringType
    {
        string Text { get; }
    }

    public class SampleClassWithStringType : ISampleClassWithStringType
    {
        public SampleClassWithStringType(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }

    public interface ISampleClassWithIntType
    {
        int Value { get; }
    }

    public class SampleClassWithIntType : ISampleClassWithIntType
    {
        public SampleClassWithIntType(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class FirstClassWithCycleInConstructor
    {
        public FirstClassWithCycleInConstructor(SecondClassWithCycleInConstructor secondClass)
        {
            SecondClass = secondClass;
        }

        public SecondClassWithCycleInConstructor SecondClass { get; private set; }
    }

    public class SecondClassWithCycleInConstructor
    {
        public SecondClassWithCycleInConstructor(FirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public FirstClassWithCycleInConstructor FirstClass { get; private set; }
    }

    public interface IFirstClassWithCycleInConstructor
    {
        ISecondClassWithCycleInConstructor SecondClass { get; }
    }

    public class FirstClassWithCycleInConstructorInRegisteredType : IFirstClassWithCycleInConstructor
    {
        public FirstClassWithCycleInConstructorInRegisteredType(ISecondClassWithCycleInConstructor secondClass)
        {
            SecondClass = secondClass;
        }

        public ISecondClassWithCycleInConstructor SecondClass { get; private set; }
    }

    public interface ISecondClassWithCycleInConstructor
    {
        IFirstClassWithCycleInConstructor FirstClass { get; }
    }

    public class SecondClassWithCycleInConstructorInRegisteredType : ISecondClassWithCycleInConstructor
    {
        public SecondClassWithCycleInConstructorInRegisteredType(IFirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public IFirstClassWithCycleInConstructor FirstClass { get; private set; }
    }

    public interface IClassWithCycleInConstructor
    {
        FirstClassWithCycleInConstructor FirstClass { get; }
    }

    public class ClassWithCycleInConstructorInRegisteredType : IClassWithCycleInConstructor
    {
        public ClassWithCycleInConstructorInRegisteredType(FirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public FirstClassWithCycleInConstructor FirstClass { get; private set; }
    }

    public interface IInterfaceWithCycleInConstructor
    {
        IFirstClassWithCycleInConstructor FirstClass { get; }
    }

    public class InterfaceWithCycleInConstructorInRegisteredType : IInterfaceWithCycleInConstructor
    {
        public InterfaceWithCycleInConstructorInRegisteredType(IFirstClassWithCycleInConstructor firstClass)
        {
            FirstClass = firstClass;
        }

        public IFirstClassWithCycleInConstructor FirstClass { get; private set; }
    }
}