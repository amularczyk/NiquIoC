using NiquIoC.Attributes;

namespace NiquIoC.Test
{
    internal interface ISampleClassWithManyDependencyProperties
    {
        EmptyClass EmptyClass { get; set; }

        ISampleClass SampleClass { get; set; }
    }

    internal class SampleClassWithManyDependencyProperties : ISampleClassWithManyDependencyProperties
    {
        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }

        [DependencyProperty]
        public ISampleClass SampleClass { get; set; }
    }

    internal interface ISampleClassWithDependencyProperty
    {
        EmptyClass EmptyClass { get; set; }
    }

    internal class SampleClassWithDependencyProperty : ISampleClassWithDependencyProperty
    {
        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }
    }

    internal class SampleClassWithoutDependencyProperty : ISampleClassWithDependencyProperty
    {
        public EmptyClass EmptyClass { get; set; }
    }

    internal interface ISampleClassWithNestedDependencyProperty
    {
        ISampleClassWithDependencyProperty SampleClassWithDependencyProperty { get; set; }
    }

    internal class SampleClassWithNestedDependencyProperty : ISampleClassWithNestedDependencyProperty
    {
        [DependencyProperty]
        public ISampleClassWithDependencyProperty SampleClassWithDependencyProperty { get; set; }
    }

    internal interface ISampleClassWithDependencyPropertyWithoutSetMethod
    {
        EmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithDependencyPropertyWithoutSetMethod : ISampleClassWithDependencyPropertyWithoutSetMethod
    {
        public SampleClassWithDependencyPropertyWithoutSetMethod()
        {
            EmptyClass = null;
        }

        [DependencyProperty]
        public EmptyClass EmptyClass { get; }
    }
}