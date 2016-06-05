namespace NiquIoC.Test.ClassDefinitions
{
    internal interface IGenericClass<T>
    {
        T NestedClass { get; }
    }

    internal class GenericClass<T> : IGenericClass<T>
    {
        public GenericClass(T nestedClass)
        {
            NestedClass = nestedClass;
        }

        public T NestedClass { get; }
    }

    internal interface IGenericClassWithManyParameters<T1, T2>
    {
        T1 NestedClass1 { get; }
        T2 NestedClass2 { get; }
    }

    internal class GenericClassWithManyParameters<T1, T2> : IGenericClassWithManyParameters<T1, T2>
    {
        public GenericClassWithManyParameters(T1 nestedClass1, T2 nestedClass2)
        {
            NestedClass1 = nestedClass1;
            NestedClass2 = nestedClass2;
        }

        public T1 NestedClass1 { get; }
        public T2 NestedClass2 { get; }
    }
}
