using DryIoc;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Reuse.Singleton);
            c.Register<ITestA1, TestA1>(Reuse.Singleton);
            c.Register<ITestA2, TestA2>(Reuse.Singleton);
            c.Register<ITestA3, TestA3>(Reuse.Singleton);
            c.Register<ITestA4, TestA4>(Reuse.Singleton);
            c.Register<ITestA5, TestA5>(Reuse.Singleton);
            c.Register<ITestA6, TestA6>(Reuse.Singleton);
            c.Register<ITestA7, TestA7>(Reuse.Singleton);
            c.Register<ITestA8, TestA8>(Reuse.Singleton);
            c.Register<ITestA9, TestA9>(Reuse.Singleton);
            c.Register<ITestA, TestA>(Reuse.Singleton);

            return c;
        }
        
        public object TransientRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>();
            c.Register<ITestA1, TestA1>();
            c.Register<ITestA2, TestA2>();
            c.Register<ITestA3, TestA3>();
            c.Register<ITestA4, TestA4>();
            c.Register<ITestA5, TestA5>();
            c.Register<ITestA6, TestA6>();
            c.Register<ITestA7, TestA7>();
            c.Register<ITestA8, TestA8>();
            c.Register<ITestA9, TestA9>();
            c.Register<ITestA, TestA>();

            return c;
        }

        public object PerThreadRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Reuse.InThread);
            c.Register<ITestA1, TestA1>(Reuse.InThread);
            c.Register<ITestA2, TestA2>(Reuse.InThread);
            c.Register<ITestA3, TestA3>(Reuse.InThread);
            c.Register<ITestA4, TestA4>(Reuse.InThread);
            c.Register<ITestA5, TestA5>(Reuse.InThread);
            c.Register<ITestA6, TestA6>(Reuse.InThread);
            c.Register<ITestA7, TestA7>(Reuse.InThread);
            c.Register<ITestA8, TestA8>(Reuse.InThread);
            c.Register<ITestA9, TestA9>(Reuse.InThread);
            c.Register<ITestA, TestA>(Reuse.InThread);

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Reuse.InWebRequest);
            c.Register<ITestA1, TestA1>(Reuse.InWebRequest);
            c.Register<ITestA2, TestA2>(Reuse.InWebRequest);
            c.Register<ITestA3, TestA3>(Reuse.InWebRequest);
            c.Register<ITestA4, TestA4>(Reuse.InWebRequest);
            c.Register<ITestA5, TestA5>(Reuse.InWebRequest);
            c.Register<ITestA6, TestA6>(Reuse.InWebRequest);
            c.Register<ITestA7, TestA7>(Reuse.InWebRequest);
            c.Register<ITestA8, TestA8>(Reuse.InWebRequest);
            c.Register<ITestA9, TestA9>(Reuse.InWebRequest);
            c.Register<ITestA, TestA>(Reuse.InWebRequest);

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestA>();
            }
        }
    }
}