using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
    internal interface ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType
    {
        IEmptyClass EmptyClassFromDependencyProperty { get; set; }

        IEmptyClass EmptyClassFromDependencyMethod { get; }

        [DependencyMethod]
        void FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType : ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType
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
    internal interface ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes
    {
        ISampleClassWithInterfaceAsParameter SampleClass { get; set; }

        IEmptyClass EmptyClass { get; }

        [DependencyMethod]
        void FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes : ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes
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