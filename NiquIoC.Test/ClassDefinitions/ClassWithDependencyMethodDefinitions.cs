using NiquIoC.Attributes;

namespace NiquIoC.Test
{
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

    internal interface ISampleClassWithMethodWithReturnType
    {
        EmptyClass EmptyClass { get; }

        bool FillEmptyClass(EmptyClass emptyClass);
    }

    internal class SampleClassWithDependencyMethodWithReturnType : ISampleClassWithMethodWithReturnType
    {
        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }
}