using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
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
    
    internal interface ISampleClassWithMethodWithInterface
    {
        IEmptyClass EmptyClass { get; }

        void FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithDependencyMethodWithInterface : ISampleClassWithMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal class SampleClassWithoutDependencyMethodWithInterface : ISampleClassWithMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal interface ISampleClassWithMethodWithInterfaceWithReturnType
    {
        IEmptyClass EmptyClass { get; }

        bool FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithDependencyMethodWithInterfaceWithReturnType : ISampleClassWithMethodWithInterfaceWithReturnType
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }

    internal class SampleClassWithDependencyPropertyAndDependencyMethod
    {
        [DependencyProperty]
        public EmptyClass EmptyClassFromDependencyProperty { get; set; }

        public EmptyClass EmptyClassFromDependencyMethod { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClassFromDependencyMethod = emptyClass;
        }
    }
}