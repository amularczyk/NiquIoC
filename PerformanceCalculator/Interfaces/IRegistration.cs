namespace PerformanceCalculator.Interfaces
{
    public interface IRegistration
    {
        object RegisterCallback(object container);

        void Register<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;
    }
}