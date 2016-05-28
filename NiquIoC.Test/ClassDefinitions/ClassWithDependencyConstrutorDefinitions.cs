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
    internal interface ISampleClassWithNestedClass
    {
        SampleClassWithDependencyConstrutor SampleClassWithDependencyConstrutor { get; }
    }

    internal class SampleClassWithNestedClassWithDependencyConstrutor : ISampleClassWithNestedClass
    {
        public SampleClassWithNestedClassWithDependencyConstrutor(SampleClassWithDependencyConstrutor sampleClassWithDependencyConstrutor)
        {
            SampleClassWithDependencyConstrutor = sampleClassWithDependencyConstrutor;
        }

        public SampleClassWithDependencyConstrutor SampleClassWithDependencyConstrutor { get; }
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
    
    internal interface ISampleClassISampleClassWithInterfaceAsParameter
    {
        ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; }
    }

    internal class SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor : ISampleClassISampleClassWithInterfaceAsParameter
    {
        [DependencyConstrutor]
        public SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor(ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter)
        {
            SampleClassWithInterfaceAsParameter = sampleClassWithInterfaceAsParameter;
        }

        public ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; }
    }
}