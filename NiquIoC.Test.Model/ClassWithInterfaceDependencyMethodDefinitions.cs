using NiquIoC.Attributes;

namespace NiquIoC.Test.Model
{
    public interface ISampleClassWithInterfaceMethod
    {
        IEmptyClass EmptyClass { get; }

        void FillEmptyClass(IEmptyClass emptyClass);
    }

    public class SampleClassWithInterfaceDependencyMethod : ISampleClassWithInterfaceMethod
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    public class SampleClassWithoutInterfaceDependencyMethod : ISampleClassWithInterfaceMethod
    {
        public IEmptyClass EmptyClass { get; private set; }

        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    public interface ISampleClassWithInterfaceMethodWithReturnType
    {
        IEmptyClass EmptyClass { get; }

        bool FillEmptyClass(IEmptyClass emptyClass);
    }

    public class SampleClassWithInterfaceDependencyMethodWithReturnType : ISampleClassWithInterfaceMethodWithReturnType
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }

    public interface ISampleClassWithManyInterfaceDependencyMethods
    {
        IEmptyClass EmptyClass { get; set; }

        ISampleClassWithInterfaceAsParameter SampleClass { get; set; }

        void FillEmptyClass(IEmptyClass emptyClass);

        void FillSampleClass(ISampleClassWithInterfaceAsParameter emptyClass);
    }

    public class SampleClassWithManyInterfaceDependencyMethods : ISampleClassWithManyInterfaceDependencyMethods
    {
        public IEmptyClass EmptyClass { get; set; }

        public ISampleClassWithInterfaceAsParameter SampleClass { get; set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        [DependencyMethod]
        public void FillSampleClass(ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter)
        {
            SampleClass = sampleClassWithInterfaceAsParameter;
        }
    }

    public interface ISampleClassWithManyInterfaceParametersInDependencyMethod
    {
        IEmptyClass EmptyClass { get; set; }

        ISampleClassWithInterfaceAsParameter SampleClass { get; set; }

        void FillClasses(IEmptyClass emptyClass,
            ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter);
    }

    public class
        SampleClassWithManyInterfaceParametersInDependencyMethod :
            ISampleClassWithManyInterfaceParametersInDependencyMethod
    {
        public IEmptyClass EmptyClass { get; set; }

        public ISampleClassWithInterfaceAsParameter SampleClass { get; set; }

        [DependencyMethod]
        public void FillClasses(IEmptyClass emptyClass,
            ISampleClassWithInterfaceAsParameter sampleClassWithInterfaceAsParameter)
        {
            EmptyClass = emptyClass;
            SampleClass = sampleClassWithInterfaceAsParameter;
        }
    }

    public interface ISampleClassWithNestedInterfaceDependencyMethod
    {
        ISampleClassWithInterfaceMethod SampleClass { get; set; }

        void FillSampleClassWithInterfaceDependencyMethod(ISampleClassWithInterfaceMethod emptyClass);
    }

    public class SampleClassWithNestedInterfaceDependencyMethod : ISampleClassWithNestedInterfaceDependencyMethod
    {
        public ISampleClassWithInterfaceMethod SampleClass { get; set; }

        [DependencyMethod]
        public void FillSampleClassWithInterfaceDependencyMethod(
            ISampleClassWithInterfaceMethod sampleClassWithInterfaceDependencyMethod)
        {
            SampleClass = sampleClassWithInterfaceDependencyMethod;
        }
    }

    public interface ISampleClassWithInterfaceMethodWithInterface
    {
        IEmptyClass EmptyClass { get; }

        void FillEmptyClass(IEmptyClass emptyClass);
    }

    public class SampleClassWithInterfaceDependencyMethodWithInterface : ISampleClassWithInterfaceMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    public class SampleClassWithoutInterfaceDependencyMethodWithInterface : ISampleClassWithInterfaceMethodWithInterface
    {
        public IEmptyClass EmptyClass { get; private set; }

        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    public interface ISampleClassWithInterfaceMethodWithInterfaceWithReturnType
    {
        IEmptyClass EmptyClass { get; }

        bool FillEmptyClass(IEmptyClass emptyClass);
    }

    public class
        SampleClassWithInterfaceDependencyMethodWithInterfaceWithReturnType :
            ISampleClassWithInterfaceMethodWithInterfaceWithReturnType
    {
        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }

    public class SampleClassWithCycleInConstructorWithInterfaceDependencyMethod : ISampleClassWithInterfaceMethod
    {
        public SampleClassWithCycleInConstructorWithInterfaceDependencyMethod(
            ISampleClassWithInterfaceMethod sampleClass)
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