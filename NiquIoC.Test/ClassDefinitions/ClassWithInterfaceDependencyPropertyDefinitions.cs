using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
    internal interface ISampleClassWithInterfaceProperty
    {
        IEmptyClass EmptyClass { get; set; }
    }

    internal class SampleClassWithInterfaceDependencyProperty : ISampleClassWithInterfaceProperty
    {
        [DependencyProperty]
        public IEmptyClass EmptyClass { get; set; }
    }

    internal class SampleClassWithoutInterfaceDependencyProperty : ISampleClassWithInterfaceProperty
    {
        public IEmptyClass EmptyClass { get; set; }
    }

    internal interface ISampleClassWithManyInterfaceDependencyProperties
    {
        IEmptyClass EmptyClass { get; set; }

        ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; set; }
    }

    internal class SampleClassWithManyInterfaceDependencyProperties : ISampleClassWithManyInterfaceDependencyProperties
    {
        [DependencyProperty]
        public IEmptyClass EmptyClass { get; set; }

        [DependencyProperty]
        public ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; set; }
    }

    internal interface ISampleClassWithNestedInterfaceDependencyProperty
    {
        ISampleClassWithInterfaceProperty SampleClassWithInterfaceDependencyProperty { get; set; }
    }

    internal class SampleClassWithNestedInterfaceDependencyProperty : ISampleClassWithNestedInterfaceDependencyProperty
    {
        [DependencyProperty]
        public ISampleClassWithInterfaceProperty SampleClassWithInterfaceDependencyProperty { get; set; }
    }

    internal interface ISampleClassWithInterfaceDependencyPropertyWithoutSetMethod
    {
        IEmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithInterfaceDependencyPropertyWithoutSetMethod : ISampleClassWithInterfaceDependencyPropertyWithoutSetMethod
    {
        public SampleClassWithInterfaceDependencyPropertyWithoutSetMethod()
        {
            EmptyClass = null;
        }

        [DependencyProperty]
        public IEmptyClass EmptyClass { get; }
    }

    internal interface ISampleClassWithInterfaceDependencyPropertyWithoutSetMethodWithInterface
    {
        IEmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithInterfaceDependencyPropertyWithoutSetMethodWithInterface : ISampleClassWithInterfaceDependencyPropertyWithoutSetMethodWithInterface
    {
        public SampleClassWithInterfaceDependencyPropertyWithoutSetMethodWithInterface()
        {
            EmptyClass = null;
        }

        [DependencyProperty]
        public IEmptyClass EmptyClass { get; }
    }
    
    internal class SampleClassWithCycleInConstructorWithInterfaceDependencyProperty : ISampleClassWithInterfaceProperty
    {
        public SampleClassWithCycleInConstructorWithInterfaceDependencyProperty(ISampleClassWithInterfaceProperty sampleClass)
        {

        }

        [DependencyProperty]
        public IEmptyClass EmptyClass { get; set; }
    }
}