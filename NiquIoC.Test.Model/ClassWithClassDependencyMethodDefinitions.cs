using NiquIoC.Attributes;

namespace NiquIoC.Test.Model
{
    public interface ISampleClassWithClassMethod
    {
        EmptyClass EmptyClass { get; }

        void FillEmptyClass(EmptyClass emptyClass);
    }

    public class SampleClassWithClassDependencyMethod : ISampleClassWithClassMethod
    {
        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    public class SampleClassWithoutClassDependencyMethod : ISampleClassWithClassMethod
    {
        public EmptyClass EmptyClass { get; private set; }

        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }

    public interface ISampleClassWithClassMethodWithReturnType
    {
        EmptyClass EmptyClass { get; }

        bool FillEmptyClass(EmptyClass emptyClass);
    }

    public class SampleClassWithClassDependencyMethodWithReturnType : ISampleClassWithClassMethodWithReturnType
    {
        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public bool FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
            return true;
        }
    }

    public interface ISampleClassWithManyClassDependencyMethods
    {
        EmptyClass EmptyClass { get; set; }

        SampleClass SampleClass { get; set; }

        void FillEmptyClass(EmptyClass emptyClass);

        void FillSampleClass(SampleClass emptyClass);
    }

    public class SampleClassWithManyClassDependencyMethods : ISampleClassWithManyClassDependencyMethods
    {
        public EmptyClass EmptyClass { get; set; }

        public SampleClass SampleClass { get; set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }

        [DependencyMethod]
        public void FillSampleClass(SampleClass sampleClass)
        {
            SampleClass = sampleClass;
        }
    }

    public interface ISampleClassWithManyClassParametersInDependencyMethod
    {
        EmptyClass EmptyClass { get; set; }

        SampleClass SampleClass { get; set; }

        void FillClasses(EmptyClass emptyClass, SampleClass sampleClass);
    }

    public class
        SampleClassWithManyClassParametersInDependencyMethod : ISampleClassWithManyClassParametersInDependencyMethod
    {
        public EmptyClass EmptyClass { get; set; }

        public SampleClass SampleClass { get; set; }

        [DependencyMethod]
        public void FillClasses(EmptyClass emptyClass, SampleClass sampleClass)
        {
            EmptyClass = emptyClass;
            SampleClass = sampleClass;
        }
    }

    public interface ISampleClassWithNestedClassDependencyMethod
    {
        SampleClassWithClassDependencyMethod SampleClassWithClassDependencyMethod { get; set; }

        void FillSampleClassWithClassDependencyMethod(SampleClassWithClassDependencyMethod emptyClass);
    }

    public class SampleClassWithNestedClassDependencyMethod : ISampleClassWithNestedClassDependencyMethod
    {
        public SampleClassWithClassDependencyMethod SampleClassWithClassDependencyMethod { get; set; }

        [DependencyMethod]
        public void FillSampleClassWithClassDependencyMethod(
            SampleClassWithClassDependencyMethod sampleClassWithClassDependencyMethod)
        {
            SampleClassWithClassDependencyMethod = sampleClassWithClassDependencyMethod;
        }
    }

    public class SampleClassWithCycleInConstructorWithClassDependencyMethod : ISampleClassWithClassMethod
    {
        public SampleClassWithCycleInConstructorWithClassDependencyMethod(
            SampleClassWithCycleInConstructorWithClassDependencyMethod sampleClass)
        {
        }

        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }
}