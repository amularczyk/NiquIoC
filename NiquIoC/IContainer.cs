namespace NiquIoC
{
    public interface IContainer
    {
        void RegisterType<T>(bool isSingleton)
            where T : class;

        void RegisterType<TFrom, TTo>(bool isSingleton)
            where TTo : TFrom;

        void RegisterInstance<T>(T instance);

        T Resolve<T>();

        void BuildUp<T>(T instance);
    }
}