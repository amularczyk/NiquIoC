using NiquIoC.Attributes;

namespace NiquIoC.Test.ClassDefinitions
{
    internal class SampleClassWithInterfaceDependencyPropertyAndDependencyMethod
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