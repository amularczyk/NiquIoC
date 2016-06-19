namespace PerformanceCalculator.Containers.TestsWindsor
{
    internal class WindsorPerformance : Performance
    {
        public override TestResult DoTestA(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestsAutofac.TestCaseA(), testCasesNumber, singleton);
        }

        public override TestResult DoTestB(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseB(), testCasesNumber, singleton);
        }

        public override TestResult DoTestC(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseC(), testCasesNumber, singleton);
        }
    }
}