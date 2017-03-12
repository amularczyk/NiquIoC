namespace PerformanceCalculator.Interfaces
{
    public interface IRegistration
    {
        object BeforeRegisterCallback(object container);

        void Register<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;
        object AfterRegisterCallback(object container);
    }
}