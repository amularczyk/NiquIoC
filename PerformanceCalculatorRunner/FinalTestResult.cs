namespace PerformanceCalculatorRunner
{
    public class FinalTestResult
    {
        public bool Singleton { get; set; }
        public int TestCasesNumber { get; set; }
        public long MinRegisterTime { get; set; }
        public long MinResolveTime { get; set; }
        public long MaxRegisterTime { get; set; }
        public long MaxResolveTime { get; set; }
        public long AvgRegisterTime { get; set; }
        public long AvgResolveTime { get; set; }
    }
}