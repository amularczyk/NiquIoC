using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
    internal interface ISampleClassWithInterfaceDependencyPropertyAndDependencyMethod
    {
        IEmptyClass EmptyClassFromDependencyProperty { get; set; }

        IEmptyClass EmptyClassFromDependencyMethod { get; }

        [DependencyMethod]
        void FillEmptyClass(IEmptyClass emptyClass);
    }

    internal class SampleClassWithInterfaceDependencyPropertyAndDependencyMethod : ISampleClassWithInterfaceDependencyPropertyAndDependencyMethod
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
}