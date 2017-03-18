namespace PerformanceCalculator.Interfaces
{
    public interface IRegistration
    {
        object BeforeRegisterCallback(object container);

        void RegisterSingleton<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;

        void RegisterTransient<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;

        void RegisterPerThread<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;

        object AfterRegisterCallback(object container);
    }
}