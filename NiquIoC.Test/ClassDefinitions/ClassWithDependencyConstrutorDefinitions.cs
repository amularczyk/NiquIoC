using NiquIoC.Attributes;

namespace NiquIoC.Test
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
}