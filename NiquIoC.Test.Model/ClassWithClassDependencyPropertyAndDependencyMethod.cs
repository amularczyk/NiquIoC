using NiquIoC.Attributes;

namespace NiquIoC.Test.Model
{
    public class SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType
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

    public class SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes
    {
        [DependencyProperty]
        public SampleClass SampleClass { get; set; }

        public EmptyClass EmptyClass { get; private set; }

        [DependencyMethod]
        public void FillEmptyClass(EmptyClass emptyClass)
        {
            EmptyClass = emptyClass;
        }
    }
}