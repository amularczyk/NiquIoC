namespace PerformanceCalculator.Common
{
    public class TestResult
    {
        public RegistrationKind RegistrationKind { get; set; }
        public int TestCasesNumber { get; set; }
        public long RegisterTime { get; set; }
        public long ResolveTime { get; set; }
    }
}