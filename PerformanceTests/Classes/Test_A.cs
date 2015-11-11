using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Classes
{
    public interface ITest_A0
    {
    }

    public class Test_A0 : ITest_A0
    {
        public Test_A0()
        { 
        }
    }

    public interface ITest_A1
    {
        ITest_A0 Test_a0 { get; }
    }

    public class Test_A1 : ITest_A1
    {
        public ITest_A0 Test_a0 { get; private set; }

        public Test_A1(ITest_A0 test_a0)
        {
            Test_a0 = test_a0;
        }
    }

    public interface ITest_A2
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
    }

    public class Test_A2 : ITest_A2
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }

        public Test_A2(ITest_A0 test_a0, ITest_A1 test_a1)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
        }
    }

    public interface ITest_A3
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
    }

    public class Test_A3 : ITest_A3
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }

        public Test_A3(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
        }
    }

    public interface ITest_A4
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
        ITest_A3 Test_a3 { get; }
    }

    public class Test_A4 : ITest_A4
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }
        public ITest_A3 Test_a3 { get; private set; }

        public Test_A4(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2, ITest_A3 test_a3)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
            Test_a3 = test_a3;
        }
    }

    public interface ITest_A5
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
        ITest_A3 Test_a3 { get; }
        ITest_A4 Test_a4 { get; }
    }

    public class Test_A5 : ITest_A5
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }
        public ITest_A3 Test_a3 { get; private set; }
        public ITest_A4 Test_a4 { get; private set; }

        public Test_A5(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2, ITest_A3 test_a3, ITest_A4 test_a4)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
            Test_a3 = test_a3;
            Test_a4 = test_a4;
        }
    }

    public interface ITest_A6
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
        ITest_A3 Test_a3 { get; }
        ITest_A4 Test_a4 { get; }
        ITest_A5 Test_a5 { get; }
    }

    public class Test_A6 : ITest_A6
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }
        public ITest_A3 Test_a3 { get; private set; }
        public ITest_A4 Test_a4 { get; private set; }
        public ITest_A5 Test_a5 { get; private set; }

        public Test_A6(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2, ITest_A3 test_a3, ITest_A4 test_a4, ITest_A5 test_a5)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
            Test_a3 = test_a3;
            Test_a4 = test_a4;
            Test_a5 = test_a5;
        }
    }

    public interface ITest_A7
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
        ITest_A3 Test_a3 { get; }
        ITest_A4 Test_a4 { get; }
        ITest_A5 Test_a5 { get; }
        ITest_A6 Test_a6 { get; }
    }

    public class Test_A7 : ITest_A7
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }
        public ITest_A3 Test_a3 { get; private set; }
        public ITest_A4 Test_a4 { get; private set; }
        public ITest_A5 Test_a5 { get; private set; }
        public ITest_A6 Test_a6 { get; private set; }

        public Test_A7(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2, ITest_A3 test_a3, ITest_A4 test_a4, ITest_A5 test_a5, ITest_A6 test_a6)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
            Test_a3 = test_a3;
            Test_a4 = test_a4;
            Test_a5 = test_a5;
            Test_a6 = test_a6;
        }
    }

    public interface ITest_A8
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
        ITest_A3 Test_a3 { get; }
        ITest_A4 Test_a4 { get; }
        ITest_A5 Test_a5 { get; }
        ITest_A6 Test_a6 { get; }
        ITest_A7 Test_a7 { get; }
    }

    public class Test_A8 : ITest_A8
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }
        public ITest_A3 Test_a3 { get; private set; }
        public ITest_A4 Test_a4 { get; private set; }
        public ITest_A5 Test_a5 { get; private set; }
        public ITest_A6 Test_a6 { get; private set; }
        public ITest_A7 Test_a7 { get; private set; }
        
        public Test_A8(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2, ITest_A3 test_a3, ITest_A4 test_a4, ITest_A5 test_a5, ITest_A6 test_a6, ITest_A7 test_a7)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
            Test_a3 = test_a3;
            Test_a4 = test_a4;
            Test_a5 = test_a5;
            Test_a6 = test_a6;
            Test_a7 = test_a7;
        }
    }

    public interface ITest_A9
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
        ITest_A3 Test_a3 { get; }
        ITest_A4 Test_a4 { get; }
        ITest_A5 Test_a5 { get; }
        ITest_A6 Test_a6 { get; }
        ITest_A7 Test_a7 { get; }
        ITest_A8 Test_a8 { get; }
    }

    public class Test_A9 : ITest_A9
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }
        public ITest_A3 Test_a3 { get; private set; }
        public ITest_A4 Test_a4 { get; private set; }
        public ITest_A5 Test_a5 { get; private set; }
        public ITest_A6 Test_a6 { get; private set; }
        public ITest_A7 Test_a7 { get; private set; }
        public ITest_A8 Test_a8 { get; private set; }

        public Test_A9(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2, ITest_A3 test_a3, ITest_A4 test_a4, ITest_A5 test_a5, ITest_A6 test_a6, ITest_A7 test_a7, ITest_A8 test_a8)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
            Test_a3 = test_a3;
            Test_a4 = test_a4;
            Test_a5 = test_a5;
            Test_a6 = test_a6;
            Test_a7 = test_a7;
            Test_a8 = test_a8;
        }
    }

    public interface ITest_A10
    {
        ITest_A0 Test_a0 { get; }
        ITest_A1 Test_a1 { get; }
        ITest_A2 Test_a2 { get; }
        ITest_A3 Test_a3 { get; }
        ITest_A4 Test_a4 { get; }
        ITest_A5 Test_a5 { get; }
        ITest_A6 Test_a6 { get; }
        ITest_A7 Test_a7 { get; }
        ITest_A8 Test_a8 { get; }
        ITest_A9 Test_a9 { get; }
    }

    public class Test_A10 : ITest_A10
    {
        public ITest_A0 Test_a0 { get; private set; }
        public ITest_A1 Test_a1 { get; private set; }
        public ITest_A2 Test_a2 { get; private set; }
        public ITest_A3 Test_a3 { get; private set; }
        public ITest_A4 Test_a4 { get; private set; }
        public ITest_A5 Test_a5 { get; private set; }
        public ITest_A6 Test_a6 { get; private set; }
        public ITest_A7 Test_a7 { get; private set; }
        public ITest_A8 Test_a8 { get; private set; }
        public ITest_A9 Test_a9 { get; private set; }

        public Test_A10(ITest_A0 test_a0, ITest_A1 test_a1, ITest_A2 test_a2, ITest_A3 test_a3, ITest_A4 test_a4, ITest_A5 test_a5, ITest_A6 test_a6, ITest_A7 test_a7, ITest_A8 test_a8, ITest_A9 test_a9)
        {
            Test_a0 = test_a0;
            Test_a1 = test_a1;
            Test_a2 = test_a2;
            Test_a3 = test_a3;
            Test_a4 = test_a4;
            Test_a5 = test_a5;
            Test_a6 = test_a6;
            Test_a7 = test_a7;
            Test_a8 = test_a8;
            Test_a9 = test_a9;
        }
    }
}
