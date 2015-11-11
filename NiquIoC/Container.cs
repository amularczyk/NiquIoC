using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiquIoC
{
    public class Container : IContainer
    {
        #region IContainer Members

        public void RegisterType<T>(bool singleton) where T : class
        {
            throw new NotImplementedException();
        }

        public void RegisterType<From, To>(bool singleton) where To : From
        {
            throw new NotImplementedException();
        }

        public void RegisterInstance<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
