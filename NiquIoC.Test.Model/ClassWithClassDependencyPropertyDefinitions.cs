using NiquIoC.Attributes;

namespace NiquIoC.Test.Model
{
    public interface ISampleClassWithClassProperty
    {
        EmptyClass EmptyClass { get; set; }
    }

    public class SampleClassWithClassDependencyProperty : ISampleClassWithClassProperty
    {
        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }
    }

    public class SampleClassWithoutClassDependencyProperty : ISampleClassWithClassProperty
    {
        public EmptyClass EmptyClass { get; set; }
    }

    public interface ISampleClassWithManyClassDependencyProperties
    {
        EmptyClass EmptyClass { get; set; }

        SampleClass SampleClass { get; set; }
    }

    public class SampleClassWithManyClassDependencyProperties : ISampleClassWithManyClassDependencyProperties
    {
        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }

        [DependencyProperty]
        public SampleClass SampleClass { get; set; }
    }

    public interface ISampleClassWithNestedClassDependencyProperty
    {
        SampleClassWithClassDependencyProperty SampleClassWithClassDependencyProperty { get; set; }
    }

    public class SampleClassWithClassInConstructorWithNestedClassDependencyProperty : ISampleClassWithNestedClassDependencyProperty
    {
        public SampleClassWithClassInConstructorWithNestedClassDependencyProperty(SampleClassWithClassDependencyProperty sampleClassWithClassDependencyProperty)
        {
            SampleClassWithClassDependencyProperty = sampleClassWithClassDependencyProperty;
        }

        public SampleClassWithClassDependencyProperty SampleClassWithClassDependencyProperty { get; set; }
    }

    public class SampleClassWithNestedClassDependencyProperty : ISampleClassWithNestedClassDependencyProperty
    {
        [DependencyProperty]
        public SampleClassWithClassDependencyProperty SampleClassWithClassDependencyProperty { get; set; }
    }

    public interface ISampleClassWithClassDependencyPropertyWithoutSetMethod
    {
        EmptyClass EmptyClass { get; }
    }

    public class SampleClassWithClassDependencyPropertyWithoutSetMethod : ISampleClassWithClassDependencyPropertyWithoutSetMethod
    {
        public SampleClassWithClassDependencyPropertyWithoutSetMethod()
        {
            EmptyClass = null;
        }

        [DependencyProperty]
        public EmptyClass EmptyClass { get; }
    }

    public interface ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface
    {
        EmptyClass EmptyClass { get; }
    }

    public class SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface : ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface
    {
        public SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface()
        {
            EmptyClass = null;
        }

        [DependencyProperty]
        public EmptyClass EmptyClass { get; }
    }

    public class SampleClassWithCycleInConstructorWithClassDependencyProperty : ISampleClassWithClassProperty
    {
        public SampleClassWithCycleInConstructorWithClassDependencyProperty(SampleClassWithCycleInConstructorWithClassDependencyProperty sampleClass)
        {

        }

        [DependencyProperty]
        public EmptyClass EmptyClass { get; set; }
    }
}