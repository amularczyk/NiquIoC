using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
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

    internal class SampleClassWithInterfaceAsParameterWithDependencyConstrutor : ISampleClassWithInterfaceAsParameter
    {
        [DependencyConstrutor]
        public SampleClassWithInterfaceAsParameterWithDependencyConstrutor(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public IEmptyClass EmptyClass { get; }
    }

    internal class SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor : ISampleClassWithInterfaceAsParameter
    {
        [DependencyConstrutor]
        public SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        [DependencyConstrutor]
        public SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor()
        {
        }

        public IEmptyClass EmptyClass { get; }
    }
}