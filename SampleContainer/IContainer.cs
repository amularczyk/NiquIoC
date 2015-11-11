using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SampleContainer
{
    public interface IContainer
    {
        void RegisterType<T>(bool singleton)
            where T : class;

        void RegisterType<From, To>(bool singleton)
            where To : From;

        void RegisterInstance<T>(T instance);

        T Resolve<T>();

        void BuildUp<T>(T instance);
    }
}
