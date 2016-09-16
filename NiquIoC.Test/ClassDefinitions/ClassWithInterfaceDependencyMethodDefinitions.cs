using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
    internal interface ISampleClassWithInterfaceMethod
    {
        IEmptyClass EmptyClass { get; }

        void FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithInterfaceDependencyMethod : ISampleClassWithInterfaceMethod
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal class SampleClassWithoutInterfaceDependencyMethod : ISampleClassWithInterfaceMethod
    {
        public IEmptyClass EmptyClass { get; private set; }
        
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal interface ISampleClassWithInterfaceMethodWithReturnType
    {
        IEmptyClass EmptyClass { get; }

        bool FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithInterfaceDependencyMethodWithReturnType : ISampleClassWithInterfaceMethodWithReturnType
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }

    internal interface ISampleClassWithManyInterfaceDependencyMethods
    {
        IEmptyClass EmptyClass { get; set; }

        void FillEmptyClass(IEmptyClass emptyClass);

        ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; set; }

        void FillSampleClass(ISampleClassWithInterfaceAsParameter emptyClass);
    }

    internal class SampleClassWithManyInterfaceDependencyMethods : ISampleClassWithManyInterfaceDependencyMethods
    {
        public IEmptyClass EmptyClass { get; set; }
        
        public ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        [DependencyMethod]
        public void FillSampleClass(ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter)
        {
            SampleClassWithInterfaceAsParameter = sampleClassWithInterfaceAsParameter;
        }
    }
    
    internal interface ISampleClassWithManyInterfaceParametersInDependencyMethod
    {
        IEmptyClass EmptyClass { get; set; }

        ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; set; }

        void FillClasses(IEmptyClass emptyClass, ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter);
    }

    internal class SampleClassWithManyInterfaceParametersInDependencyMethod : ISampleClassWithManyInterfaceParametersInDependencyMethod
    {
        public IEmptyClass EmptyClass { get; set; }

        public ISampleClassWithInterfaceAsParameter SampleClassWithInterfaceAsParameter { get; set; }

        [DependencyMethod]
        public void FillClasses(IEmptyClass emptyClass, ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter)
        {
            EmptyClass = emptyClass;
            SampleClassWithInterfaceAsParameter = sampleClassWithInterfaceAsParameter;
        }
    }

    internal interface ISampleClassWithNestedInterfaceDependencyMethod
    {
        ISampleClassWithInterfaceMethod SampleClassWithInterfaceDependencyMethod { get; set; }

        void FillSampleClassWithInterfaceDependencyMethod(ISampleClassWithInterfaceMethod emptyClass);
    }

    internal class SampleClassWithNestedInterfaceDependencyMethod : ISampleClassWithNestedInterfaceDependencyMethod
    {
        public ISampleClassWithInterfaceMethod SampleClassWithInterfaceDependencyMethod { get; set; }

        [DependencyMethod]
        public void FillSampleClassWithInterfaceDependencyMethod(ISampleClassWithInterfaceMethod sampleClassWithInterfaceDependencyMethod)
        {
            SampleClassWithInterfaceDependencyMethod = sampleClassWithInterfaceDependencyMethod;
        }
    }

    internal interface ISampleClassWithInterfaceMethodWithInterface
    {
        IEmptyClass EmptyClass { get; }

        void FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithInterfaceDependencyMethodWithInterface : ISampleClassWithInterfaceMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal class SampleClassWithoutInterfaceDependencyMethodWithInterface : ISampleClassWithInterfaceMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    internal interface ISampleClassWithInterfaceMethodWithInterfaceWithReturnType
    {
        IEmptyClass EmptyClass { get; }

        bool FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithInterfaceDependencyMethodWithInterfaceWithReturnType : ISampleClassWithInterfaceMethodWithInterfaceWithReturnType
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }

    internal class SampleClassWithCycleInConstructorWithInterfaceDependencyMethod : ISampleClassWithInterfaceMethod
    {
        public SampleClassWithCycleInConstructorWithInterfaceDependencyMethod(ISampleClassWithInterfaceMethod sampleClass)
        {

        }

        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }
}