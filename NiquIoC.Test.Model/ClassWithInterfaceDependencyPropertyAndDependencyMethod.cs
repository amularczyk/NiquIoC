using NiquIoC.Attributes;

namespace NiquIoC.Test.Model
{
    public interface ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType
    {
        IEmptyClass EmptyClassFromDependencyProperty { get; set; }

        IEmptyClass EmptyClassFromDependencyMethod { get; }

        [DependencyMethod]
        void FillEmptyClass(IEmptyClass emptyClass);
    }

    public class SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType :
        ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType
    {
        [DependencyProperty]
        public IEmptyClass EmptyClassFromDependencyProperty { get; set; }

        public IEmptyClass EmptyClassFromDependencyMethod { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClassFromDependencyMethod = emptyClass;
        }
    }

    public interface ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes
    {
        ISampleClassWithInterfaceAsParameter SampleClass { get; set; }

        IEmptyClass EmptyClass { get; }

        [DependencyMethod]
        void FillEmptyClass(IEmptyClass emptyClass);
    }

    public class SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes :
        ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes
    {
        [DependencyProperty]
        public ISampleClassWithInterfaceAsParameter SampleClass { get; set; }

        public IEmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(IEmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }
}