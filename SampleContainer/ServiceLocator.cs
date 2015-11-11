using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleContainer
{
    public delegate IContainer ContainerProviderDelegate();

    public class ServiceLocator
    {
        private static object _obj = new object();
        private static ServiceLocator _current;
        private static ContainerProviderDelegate _containerProvider;

        private ServiceLocator() { }

        public static void SetContainerProvider(ContainerProviderDelegate containerProvider)
        {
            _containerProvider = containerProvider;
        }

        public static ServiceLocator Current
        {
            get
            {
                if (_current == null)
                {
                    lock (_obj)
                    {
                        if (_current == null)
                        {
                            _current = new ServiceLocator();
                        }
                    }
                }
                return _current;
            }
        }

        public T GetInstance<T>()
        {
            if (typeof(T) == typeof(IContainer))
            {
                return (T)_containerProvider();
            }
            else
            {
                return _containerProvider().Resolve<T>();
            }
        }
    }
}
