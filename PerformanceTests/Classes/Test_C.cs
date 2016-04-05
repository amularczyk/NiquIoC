namespace PerformanceTests.Classes
{
    public interface ITestCa0
    {
    }

    public class TestCa0 : ITestCa0
    {
    }

    public interface ITestCa1
    {
        ITestCa0 TestCa0 { get; }
    }

    public class TestCa1 : ITestCa1
    {
        public TestCa1(ITestCa0 testCa0)
        {
            TestCa0 = testCa0;
        }

        public ITestCa0 TestCa0 { get; }
    }

    public interface ITestCa2
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
    }

    public class TestCa2 : ITestCa2
    {
        public TestCa2(ITestCa0 testCa0, ITestCa1 testCa1)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
    }

    public interface ITestCa3
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
    }

    public class TestCa3 : ITestCa3
    {
        public TestCa3(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
    }

    public interface ITestCa4
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
        ITestCa3 TestCa3 { get; }
    }

    public class TestCa4 : ITestCa4
    {
        public TestCa4(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2, ITestCa3 testCa3)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
            TestCa3 = testCa3;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
        public ITestCa3 TestCa3 { get; }
    }

    public interface ITestCa5
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
        ITestCa3 TestCa3 { get; }
        ITestCa4 TestCa4 { get; }
    }

    public class TestCa5 : ITestCa5
    {
        public TestCa5(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2, ITestCa3 testCa3, ITestCa4 testCa4)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
            TestCa3 = testCa3;
            TestCa4 = testCa4;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
        public ITestCa3 TestCa3 { get; }
        public ITestCa4 TestCa4 { get; }
    }

    public interface ITestCa6
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
        ITestCa3 TestCa3 { get; }
        ITestCa4 TestCa4 { get; }
        ITestCa5 TestCa5 { get; }
    }

    public class TestCa6 : ITestCa6
    {
        public TestCa6(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2, ITestCa3 testCa3, ITestCa4 testCa4, ITestCa5 testCa5)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
            TestCa3 = testCa3;
            TestCa4 = testCa4;
            TestCa5 = testCa5;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
        public ITestCa3 TestCa3 { get; }
        public ITestCa4 TestCa4 { get; }
        public ITestCa5 TestCa5 { get; }
    }

    public interface ITestCa7
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
        ITestCa3 TestCa3 { get; }
        ITestCa4 TestCa4 { get; }
        ITestCa5 TestCa5 { get; }
        ITestCa6 TestCa6 { get; }
    }

    public class TestCa7 : ITestCa7
    {
        public TestCa7(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2, ITestCa3 testCa3, ITestCa4 testCa4, ITestCa5 testCa5, ITestCa6 testCa6)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
            TestCa3 = testCa3;
            TestCa4 = testCa4;
            TestCa5 = testCa5;
            TestCa6 = testCa6;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
        public ITestCa3 TestCa3 { get; }
        public ITestCa4 TestCa4 { get; }
        public ITestCa5 TestCa5 { get; }
        public ITestCa6 TestCa6 { get; }
    }

    public interface ITestCa8
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
        ITestCa3 TestCa3 { get; }
        ITestCa4 TestCa4 { get; }
        ITestCa5 TestCa5 { get; }
        ITestCa6 TestCa6 { get; }
        ITestCa7 TestCa7 { get; }
    }

    public class TestCa8 : ITestCa8
    {
        public TestCa8(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2, ITestCa3 testCa3, ITestCa4 testCa4, ITestCa5 testCa5, ITestCa6 testCa6,
            ITestCa7 testCa7)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
            TestCa3 = testCa3;
            TestCa4 = testCa4;
            TestCa5 = testCa5;
            TestCa6 = testCa6;
            TestCa7 = testCa7;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
        public ITestCa3 TestCa3 { get; }
        public ITestCa4 TestCa4 { get; }
        public ITestCa5 TestCa5 { get; }
        public ITestCa6 TestCa6 { get; }
        public ITestCa7 TestCa7 { get; }
    }

    public interface ITestCa9
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
        ITestCa3 TestCa3 { get; }
        ITestCa4 TestCa4 { get; }
        ITestCa5 TestCa5 { get; }
        ITestCa6 TestCa6 { get; }
        ITestCa7 TestCa7 { get; }
        ITestCa8 TestCa8 { get; }
    }

    public class TestCa9 : ITestCa9
    {
        public TestCa9(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2, ITestCa3 testCa3, ITestCa4 testCa4, ITestCa5 testCa5, ITestCa6 testCa6,
            ITestCa7 testCa7, ITestCa8 testCa8)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
            TestCa3 = testCa3;
            TestCa4 = testCa4;
            TestCa5 = testCa5;
            TestCa6 = testCa6;
            TestCa7 = testCa7;
            TestCa8 = testCa8;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
        public ITestCa3 TestCa3 { get; }
        public ITestCa4 TestCa4 { get; }
        public ITestCa5 TestCa5 { get; }
        public ITestCa6 TestCa6 { get; }
        public ITestCa7 TestCa7 { get; }
        public ITestCa8 TestCa8 { get; }
    }

    public interface ITestCa10
    {
        ITestCa0 TestCa0 { get; }
        ITestCa1 TestCa1 { get; }
        ITestCa2 TestCa2 { get; }
        ITestCa3 TestCa3 { get; }
        ITestCa4 TestCa4 { get; }
        ITestCa5 TestCa5 { get; }
        ITestCa6 TestCa6 { get; }
        ITestCa7 TestCa7 { get; }
        ITestCa8 TestCa8 { get; }
        ITestCa9 TestCa9 { get; }
    }

    public class TestCa10 : ITestCa10
    {
        public TestCa10(ITestCa0 testCa0, ITestCa1 testCa1, ITestCa2 testCa2, ITestCa3 testCa3, ITestCa4 testCa4, ITestCa5 testCa5, ITestCa6 testCa6,
            ITestCa7 testCa7, ITestCa8 testCa8, ITestCa9 testCa9)
        {
            TestCa0 = testCa0;
            TestCa1 = testCa1;
            TestCa2 = testCa2;
            TestCa3 = testCa3;
            TestCa4 = testCa4;
            TestCa5 = testCa5;
            TestCa6 = testCa6;
            TestCa7 = testCa7;
            TestCa8 = testCa8;
            TestCa9 = testCa9;
        }

        public ITestCa0 TestCa0 { get; }
        public ITestCa1 TestCa1 { get; }
        public ITestCa2 TestCa2 { get; }
        public ITestCa3 TestCa3 { get; }
        public ITestCa4 TestCa4 { get; }
        public ITestCa5 TestCa5 { get; }
        public ITestCa6 TestCa6 { get; }
        public ITestCa7 TestCa7 { get; }
        public ITestCa8 TestCa8 { get; }
        public ITestCa9 TestCa9 { get; }
    }


    public interface ITestCb0
    {
    }

    public class TestCb0 : ITestCb0
    {
    }

    public interface ITestCb1
    {
        ITestCb0 TestCb0 { get; }
    }

    public class TestCb1 : ITestCb1
    {
        public TestCb1(ITestCb0 testCb0)
        {
            TestCb0 = testCb0;
        }

        public ITestCb0 TestCb0 { get; }
    }

    public interface ITestCb2
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
    }

    public class TestCb2 : ITestCb2
    {
        public TestCb2(ITestCb0 testCb0, ITestCb1 testCb1)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
    }

    public interface ITestCb3
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
    }

    public class TestCb3 : ITestCb3
    {
        public TestCb3(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
    }

    public interface ITestCb4
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
        ITestCb3 TestCb3 { get; }
    }

    public class TestCb4 : ITestCb4
    {
        public TestCb4(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2, ITestCb3 testCb3)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
            TestCb3 = testCb3;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
        public ITestCb3 TestCb3 { get; }
    }

    public interface ITestCb5
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
        ITestCb3 TestCb3 { get; }
        ITestCb4 TestCb4 { get; }
    }

    public class TestCb5 : ITestCb5
    {
        public TestCb5(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2, ITestCb3 testCb3, ITestCb4 testCb4)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
            TestCb3 = testCb3;
            TestCb4 = testCb4;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
        public ITestCb3 TestCb3 { get; }
        public ITestCb4 TestCb4 { get; }
    }

    public interface ITestCb6
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
        ITestCb3 TestCb3 { get; }
        ITestCb4 TestCb4 { get; }
        ITestCb5 TestCb5 { get; }
    }

    public class TestCb6 : ITestCb6
    {
        public TestCb6(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2, ITestCb3 testCb3, ITestCb4 testCb4, ITestCb5 testCb5)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
            TestCb3 = testCb3;
            TestCb4 = testCb4;
            TestCb5 = testCb5;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
        public ITestCb3 TestCb3 { get; }
        public ITestCb4 TestCb4 { get; }
        public ITestCb5 TestCb5 { get; }
    }

    public interface ITestCb7
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
        ITestCb3 TestCb3 { get; }
        ITestCb4 TestCb4 { get; }
        ITestCb5 TestCb5 { get; }
        ITestCb6 TestCb6 { get; }
    }

    public class TestCb7 : ITestCb7
    {
        public TestCb7(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2, ITestCb3 testCb3, ITestCb4 testCb4, ITestCb5 testCb5, ITestCb6 testCb6)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
            TestCb3 = testCb3;
            TestCb4 = testCb4;
            TestCb5 = testCb5;
            TestCb6 = testCb6;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
        public ITestCb3 TestCb3 { get; }
        public ITestCb4 TestCb4 { get; }
        public ITestCb5 TestCb5 { get; }
        public ITestCb6 TestCb6 { get; }
    }

    public interface ITestCb8
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
        ITestCb3 TestCb3 { get; }
        ITestCb4 TestCb4 { get; }
        ITestCb5 TestCb5 { get; }
        ITestCb6 TestCb6 { get; }
        ITestCb7 TestCb7 { get; }
    }

    public class TestCb8 : ITestCb8
    {
        public TestCb8(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2, ITestCb3 testCb3, ITestCb4 testCb4, ITestCb5 testCb5, ITestCb6 testCb6,
            ITestCb7 testCb7)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
            TestCb3 = testCb3;
            TestCb4 = testCb4;
            TestCb5 = testCb5;
            TestCb6 = testCb6;
            TestCb7 = testCb7;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
        public ITestCb3 TestCb3 { get; }
        public ITestCb4 TestCb4 { get; }
        public ITestCb5 TestCb5 { get; }
        public ITestCb6 TestCb6 { get; }
        public ITestCb7 TestCb7 { get; }
    }

    public interface ITestCb9
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
        ITestCb3 TestCb3 { get; }
        ITestCb4 TestCb4 { get; }
        ITestCb5 TestCb5 { get; }
        ITestCb6 TestCb6 { get; }
        ITestCb7 TestCb7 { get; }
        ITestCb8 TestCb8 { get; }
    }

    public class TestCb9 : ITestCb9
    {
        public TestCb9(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2, ITestCb3 testCb3, ITestCb4 testCb4, ITestCb5 testCb5, ITestCb6 testCb6,
            ITestCb7 testCb7, ITestCb8 testCb8)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
            TestCb3 = testCb3;
            TestCb4 = testCb4;
            TestCb5 = testCb5;
            TestCb6 = testCb6;
            TestCb7 = testCb7;
            TestCb8 = testCb8;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
        public ITestCb3 TestCb3 { get; }
        public ITestCb4 TestCb4 { get; }
        public ITestCb5 TestCb5 { get; }
        public ITestCb6 TestCb6 { get; }
        public ITestCb7 TestCb7 { get; }
        public ITestCb8 TestCb8 { get; }
    }

    public interface ITestCb10
    {
        ITestCb0 TestCb0 { get; }
        ITestCb1 TestCb1 { get; }
        ITestCb2 TestCb2 { get; }
        ITestCb3 TestCb3 { get; }
        ITestCb4 TestCb4 { get; }
        ITestCb5 TestCb5 { get; }
        ITestCb6 TestCb6 { get; }
        ITestCb7 TestCb7 { get; }
        ITestCb8 TestCb8 { get; }
        ITestCb9 TestCb9 { get; }
    }

    public class TestCb10 : ITestCb10
    {
        public TestCb10(ITestCb0 testCb0, ITestCb1 testCb1, ITestCb2 testCb2, ITestCb3 testCb3, ITestCb4 testCb4, ITestCb5 testCb5, ITestCb6 testCb6,
            ITestCb7 testCb7, ITestCb8 testCb8, ITestCb9 testCb9)
        {
            TestCb0 = testCb0;
            TestCb1 = testCb1;
            TestCb2 = testCb2;
            TestCb3 = testCb3;
            TestCb4 = testCb4;
            TestCb5 = testCb5;
            TestCb6 = testCb6;
            TestCb7 = testCb7;
            TestCb8 = testCb8;
            TestCb9 = testCb9;
        }

        public ITestCb0 TestCb0 { get; }
        public ITestCb1 TestCb1 { get; }
        public ITestCb2 TestCb2 { get; }
        public ITestCb3 TestCb3 { get; }
        public ITestCb4 TestCb4 { get; }
        public ITestCb5 TestCb5 { get; }
        public ITestCb6 TestCb6 { get; }
        public ITestCb7 TestCb7 { get; }
        public ITestCb8 TestCb8 { get; }
        public ITestCb9 TestCb9 { get; }
    }


    public interface ITestCc0
    {
    }

    public class TestCc0 : ITestCc0
    {
    }

    public interface ITestCc1
    {
        ITestCc0 TestCc0 { get; }
    }

    public class TestCc1 : ITestCc1
    {
        public TestCc1(ITestCc0 testCc0)
        {
            TestCc0 = testCc0;
        }

        public ITestCc0 TestCc0 { get; }
    }

    public interface ITestCc2
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
    }

    public class TestCc2 : ITestCc2
    {
        public TestCc2(ITestCc0 testCc0, ITestCc1 testCc1)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
    }

    public interface ITestCc3
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
    }

    public class TestCc3 : ITestCc3
    {
        public TestCc3(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
    }

    public interface ITestCc4
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
        ITestCc3 TestCc3 { get; }
    }

    public class TestCc4 : ITestCc4
    {
        public TestCc4(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2, ITestCc3 testCc3)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
            TestCc3 = testCc3;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
        public ITestCc3 TestCc3 { get; }
    }

    public interface ITestCc5
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
        ITestCc3 TestCc3 { get; }
        ITestCc4 TestCc4 { get; }
    }

    public class TestCc5 : ITestCc5
    {
        public TestCc5(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2, ITestCc3 testCc3, ITestCc4 testCc4)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
            TestCc3 = testCc3;
            TestCc4 = testCc4;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
        public ITestCc3 TestCc3 { get; }
        public ITestCc4 TestCc4 { get; }
    }

    public interface ITestCc6
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
        ITestCc3 TestCc3 { get; }
        ITestCc4 TestCc4 { get; }
        ITestCc5 TestCc5 { get; }
    }

    public class TestCc6 : ITestCc6
    {
        public TestCc6(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2, ITestCc3 testCc3, ITestCc4 testCc4, ITestCc5 testCc5)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
            TestCc3 = testCc3;
            TestCc4 = testCc4;
            TestCc5 = testCc5;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
        public ITestCc3 TestCc3 { get; }
        public ITestCc4 TestCc4 { get; }
        public ITestCc5 TestCc5 { get; }
    }

    public interface ITestCc7
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
        ITestCc3 TestCc3 { get; }
        ITestCc4 TestCc4 { get; }
        ITestCc5 TestCc5 { get; }
        ITestCc6 TestCc6 { get; }
    }

    public class TestCc7 : ITestCc7
    {
        public TestCc7(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2, ITestCc3 testCc3, ITestCc4 testCc4, ITestCc5 testCc5, ITestCc6 testCc6)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
            TestCc3 = testCc3;
            TestCc4 = testCc4;
            TestCc5 = testCc5;
            TestCc6 = testCc6;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
        public ITestCc3 TestCc3 { get; }
        public ITestCc4 TestCc4 { get; }
        public ITestCc5 TestCc5 { get; }
        public ITestCc6 TestCc6 { get; }
    }

    public interface ITestCc8
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
        ITestCc3 TestCc3 { get; }
        ITestCc4 TestCc4 { get; }
        ITestCc5 TestCc5 { get; }
        ITestCc6 TestCc6 { get; }
        ITestCc7 TestCc7 { get; }
    }

    public class TestCc8 : ITestCc8
    {
        public TestCc8(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2, ITestCc3 testCc3, ITestCc4 testCc4, ITestCc5 testCc5, ITestCc6 testCc6,
            ITestCc7 testCc7)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
            TestCc3 = testCc3;
            TestCc4 = testCc4;
            TestCc5 = testCc5;
            TestCc6 = testCc6;
            TestCc7 = testCc7;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
        public ITestCc3 TestCc3 { get; }
        public ITestCc4 TestCc4 { get; }
        public ITestCc5 TestCc5 { get; }
        public ITestCc6 TestCc6 { get; }
        public ITestCc7 TestCc7 { get; }
    }

    public interface ITestCc9
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
        ITestCc3 TestCc3 { get; }
        ITestCc4 TestCc4 { get; }
        ITestCc5 TestCc5 { get; }
        ITestCc6 TestCc6 { get; }
        ITestCc7 TestCc7 { get; }
        ITestCc8 TestCc8 { get; }
    }

    public class TestCc9 : ITestCc9
    {
        public TestCc9(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2, ITestCc3 testCc3, ITestCc4 testCc4, ITestCc5 testCc5, ITestCc6 testCc6,
            ITestCc7 testCc7, ITestCc8 testCc8)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
            TestCc3 = testCc3;
            TestCc4 = testCc4;
            TestCc5 = testCc5;
            TestCc6 = testCc6;
            TestCc7 = testCc7;
            TestCc8 = testCc8;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
        public ITestCc3 TestCc3 { get; }
        public ITestCc4 TestCc4 { get; }
        public ITestCc5 TestCc5 { get; }
        public ITestCc6 TestCc6 { get; }
        public ITestCc7 TestCc7 { get; }
        public ITestCc8 TestCc8 { get; }
    }

    public interface ITestCc10
    {
        ITestCc0 TestCc0 { get; }
        ITestCc1 TestCc1 { get; }
        ITestCc2 TestCc2 { get; }
        ITestCc3 TestCc3 { get; }
        ITestCc4 TestCc4 { get; }
        ITestCc5 TestCc5 { get; }
        ITestCc6 TestCc6 { get; }
        ITestCc7 TestCc7 { get; }
        ITestCc8 TestCc8 { get; }
        ITestCc9 TestCc9 { get; }
    }

    public class TestCc10 : ITestCc10
    {
        public TestCc10(ITestCc0 testCc0, ITestCc1 testCc1, ITestCc2 testCc2, ITestCc3 testCc3, ITestCc4 testCc4, ITestCc5 testCc5, ITestCc6 testCc6,
            ITestCc7 testCc7, ITestCc8 testCc8, ITestCc9 testCc9)
        {
            TestCc0 = testCc0;
            TestCc1 = testCc1;
            TestCc2 = testCc2;
            TestCc3 = testCc3;
            TestCc4 = testCc4;
            TestCc5 = testCc5;
            TestCc6 = testCc6;
            TestCc7 = testCc7;
            TestCc8 = testCc8;
            TestCc9 = testCc9;
        }

        public ITestCc0 TestCc0 { get; }
        public ITestCc1 TestCc1 { get; }
        public ITestCc2 TestCc2 { get; }
        public ITestCc3 TestCc3 { get; }
        public ITestCc4 TestCc4 { get; }
        public ITestCc5 TestCc5 { get; }
        public ITestCc6 TestCc6 { get; }
        public ITestCc7 TestCc7 { get; }
        public ITestCc8 TestCc8 { get; }
        public ITestCc9 TestCc9 { get; }
    }


    public interface ITestC
    {
        ITestCa10 TestCa10 { get; }
        ITestCb10 TestCb10 { get; }
        ITestCc10 TestCc10 { get; }
    }

    public class TestC : ITestC
    {
        public TestC(ITestCa10 testCa10, ITestCb10 testCb10, ITestCc10 testCc10)
        {
            TestCa10 = testCa10;
            TestCb10 = testCb10;
            TestCc10 = testCc10;
        }

        public ITestCa10 TestCa10 { get; }
        public ITestCb10 TestCb10 { get; }
        public ITestCc10 TestCc10 { get; }
    }
}