using NiquIoC.Attributes;

namespace NiquIoC.Test.Model
{
    public class SampleClassWithDependencyConstrutor : ISampleClass
    {
        [DependencyConstrutor]
        public SampleClassWithDependencyConstrutor(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
        
        public EmptyClass EmptyClass { get; }
    }

    public class SampleClassWithTwoDependencyConstrutor : ISampleClass
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
    public interface ISampleClassWithNestedClass
    {
        SampleClassWithDependencyConstrutor SampleClassWithDependencyConstrutor { get; }
    }

    public class SampleClassWithNestedClassWithDependencyConstrutor : ISampleClassWithNestedClass
    {
        public SampleClassWithNestedClassWithDependencyConstrutor(SampleClassWithDependencyConstrutor sampleClassWithDependencyConstrutor)
        {
            SampleClassWithDependencyConstrutor = sampleClassWithDependencyConstrutor;
        }

        public SampleClassWithDependencyConstrutor SampleClassWithDependencyConstrutor { get; }
    }

    public class SampleClassWithInterfaceAsParameterWithDependencyConstrutor : ISampleClassWithInterfaceAsParameter
    {
        [DependencyConstrutor]
        public SampleClassWithInterfaceAsParameterWithDependencyConstrutor(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        public IEmptyClass EmptyClass { get; }
    }

    public class SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor : ISampleClassWithInterfaceAsParameter
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
    
    public interface ISampleClassISampleClassWithInterfaceAsParameter
    {
        ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; }
    }

    public class SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor : ISampleClassISampleClassWithInterfaceAsParameter
    {
        [DependencyConstrutor]
        public SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor(ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter)
        {
            SampleClassWithInterfaceAsParameter = sampleClassWithInterfaceAsParameter;
        }

        public ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; }
    }
}