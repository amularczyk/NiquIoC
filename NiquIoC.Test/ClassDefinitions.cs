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

    internal class SampleClassWithDependencyConstrutor : ISampleClass
    {
        [DependencyConstrutor]
        public SampleClassWithDependencyConstrutor(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
        
        public EmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithTwoDependencyConstrutor : ISampleClass
    {
        [DependencyConstrutor]
        public SampleClassWithTwoDependencyConstrutor(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        [DependencyConstrutor]
        public SampleClassWithTwoDependencyConstrutor()
        {
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

    internal interface ISampleClassWithMethod
    {
        EmptyClass EmptyClass { get; }

        void FillEmptyClass(EmptyClass emptyClass);
    }

    internal class SampleClassWithDependencyMethod : ISampleClassWithMethod
    {
        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal class SampleClassWithoutDependencyMethod : ISampleClassWithMethod
    {
        public EmptyClass EmptyClass { get; private set; }
        
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }
}