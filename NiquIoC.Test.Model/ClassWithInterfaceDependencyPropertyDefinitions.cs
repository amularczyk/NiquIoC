using NiquIoC.Attributes;

namespace NiquIoC.Test.Model
{
    public interface ISampleClassWithInterfaceProperty
    {
        IEmptyClass EmptyClass { get; set; }
    }

    public class SampleClassWithInterfaceDependencyProperty : ISampleClassWithInterfaceProperty
    {
        [DependencyProperty]
        public IEmptyClass EmptyClass { get; set; }
    }

    public class SampleClassWithoutInterfaceDependencyProperty : ISampleClassWithInterfaceProperty
    {
        public IEmptyClass EmptyClass { get; set; }
    }

    public interface ISampleClassWithManyInterfaceDependencyProperties
    {
        IEmptyClass EmptyClass { get; set; }

        ISampleClassWithInterfaceAsParameter SampleClass { get; set; }
    }

    public class SampleClassWithManyInterfaceDependencyProperties : ISampleClassWithManyInterfaceDependencyProperties
    {
        [DependencyProperty]
        public IEmptyClass EmptyClass { get; set; }

        [DependencyProperty]
        public ISampleClassWithInterfaceAsParameter SampleClass { get; set; }
    }

    public interface ISampleClassWithNestedInterfaceDependencyProperty
    {
        ISampleClassWithInterfaceProperty SampleClassWithInterfaceDependencyProperty { get; set; }
    }

    public class SampleClassWithNestedInterfaceDependencyProperty : ISampleClassWithNestedInterfaceDependencyProperty
    {
        [DependencyProperty]
        public ISampleClassWithInterfaceProperty SampleClassWithInterfaceDependencyProperty { get; set; }
    }

    public class
        SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty :
            ISampleClassWithNestedInterfaceDependencyProperty
    {
        public SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty(
            ISampleClassWithInterfaceProperty sampleClassWithInterfaceDependencyProperty)
        {
            SampleClassWithInterfaceDependencyProperty = sampleClassWithInterfaceDependencyProperty;
        }

        public ISampleClassWithInterfaceProperty SampleClassWithInterfaceDependencyProperty { get; set; }
    }

    public class SampleClassWithCycleInConstructorWithInterfaceDependencyProperty : ISampleClassWithInterfaceProperty
    {
        public SampleClassWithCycleInConstructorWithInterfaceDependencyProperty(
            ISampleClassWithInterfaceProperty sampleClass)
        {
        }

        [DependencyProperty]
        public IEmptyClass EmptyClass { get; set; }
    }
}