using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
    internal interface ISampleClassWithClassProperty
    {
        EmptyClass EmptyClass { get; set; }
    }

    internal class SampleClassWithClassDependencyProperty : ISampleClassWithClassProperty
    {
        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }
    }

    internal class SampleClassWithoutClassDependencyProperty : ISampleClassWithClassProperty
    {
        public EmptyClass EmptyClass { get; set; }
    }

    internal interface ISampleClassWithManyClassDependencyProperties
    {
        EmptyClass EmptyClass { get; set; }

        SampleClass SampleClass { get; set; }
    }

    internal class SampleClassWithManyClassDependencyProperties : ISampleClassWithManyClassDependencyProperties
    {
        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }

        [DependencyProperty]
        public SampleClass SampleClass { get; set; }
    }

    internal interface ISampleClassWithNestedClassDependencyProperty
    {
        SampleClassWithClassDependencyProperty SampleClassWithClassDependencyProperty { get; set; }
    }

    internal class SampleClassWithClassInConstructorWithNestedClassDependencyProperty : ISampleClassWithNestedClassDependencyProperty
    {
        public SampleClassWithClassInConstructorWithNestedClassDependencyProperty(SampleClassWithClassDependencyProperty sampleClassWithClassDependencyProperty)
        {
            SampleClassWithClassDependencyProperty = sampleClassWithClassDependencyProperty;
        }

        public SampleClassWithClassDependencyProperty SampleClassWithClassDependencyProperty { get; set; }
    }

    internal class SampleClassWithNestedClassDependencyProperty : ISampleClassWithNestedClassDependencyProperty
    {
        [DependencyProperty]
        public SampleClassWithClassDependencyProperty SampleClassWithClassDependencyProperty { get; set; }
    }

    internal interface ISampleClassWithClassDependencyPropertyWithoutSetMethod
    {
        EmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithClassDependencyPropertyWithoutSetMethod : ISampleClassWithClassDependencyPropertyWithoutSetMethod
    {
        public SampleClassWithClassDependencyPropertyWithoutSetMethod()
        {
            EmptyClass = null;
        }

        [DependencyProperty]
        public EmptyClass EmptyClass { get; }
    }

    internal interface ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface
    {
        EmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface : ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface
    {
        public SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface()
        {
            EmptyClass = null;
        }

        [DependencyProperty]
        public EmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithCycleInConstructorWithClassDependencyProperty : ISampleClassWithClassProperty
    {
        public SampleClassWithCycleInConstructorWithClassDependencyProperty(SampleClassWithCycleInConstructorWithClassDependencyProperty sampleClass)
        {

        }

        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }
    }
}