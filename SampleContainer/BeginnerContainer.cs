using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SampleContainer
{
    public class BeginnerContainer : IContainer
    {
        Dictionary<Type, Tuple<bool, object>> _classContainer;
        Dictionary<Type, Tuple<bool, Type, object>> _interfaceContainer;

        public BeginnerContainer()
        {
            _classContainer = new Dictionary<Type, Tuple<bool, object>>();
            _interfaceContainer = new Dictionary<Type, Tuple<bool, Type, object>>();
        }

        public void RegisterType<T>(bool singleton)
            where T : class
        {
            if (!_classContainer.ContainsKey(typeof(T)))
            {
                _classContainer.Add(typeof(T), Tuple.Create(singleton, (object)null));
            }
            else
            {
                _classContainer[typeof(T)] = Tuple.Create(singleton, (object)null);
            }
        }

        public void RegisterType<From, To>(bool singleton)
            where To : From
        {
            if (!_interfaceContainer.ContainsKey(typeof(From)))
            {
                _interfaceContainer.Add(typeof(From), Tuple.Create(singleton, typeof(To), (object)null));
            }
            else
            {
                _interfaceContainer[typeof(From)] = Tuple.Create(singleton, typeof(To), (object)null);
            }
        }

        public void RegisterInstance<T>(T instance)
        {
            if (typeof(T).IsInterface)
            {
                if (!_interfaceContainer.ContainsKey(typeof(T)))
                {
                    _interfaceContainer.Add(typeof(T), Tuple.Create(true, instance.GetType(), (object)instance));
                }
                else
                {
                    _interfaceContainer[typeof(T)] = Tuple.Create(true, instance.GetType(), (object)instance);
                }
            }
            else
            {
                if (!_classContainer.ContainsKey(typeof(T)))
                {
                    _classContainer.Add(typeof(T), Tuple.Create(true, (object)instance));
                }
                else
                {
                    _classContainer[typeof(T)] = Tuple.Create(true, (object)instance);
                }
            }
        }

        public T Resolve<T>()
        {
            if (typeof(T).IsInterface)
            {
                if (_interfaceContainer.ContainsKey(typeof(T)))
                {
                    var result = _interfaceContainer[typeof(T)];
                    if (result.Item1)
                    {
                        object value = result.Item3;
                        if (value == null)
                        {
                            value = Activator.CreateInstance(result.Item2);
                            _interfaceContainer[typeof(T)] = Tuple.Create(result.Item1, result.Item2, value);
                        }
                        return (T)value;
                    }
                    else
                    {
                        return (T)Activator.CreateInstance(result.Item2);
                    }
                }
            }
            else
            {
                if (_classContainer.ContainsKey(typeof(T)))
                {
                    var result = _classContainer[typeof(T)];
                    if (result.Item1)
                    {
                        object value = result.Item2;
                        if (value == null)
                        {
                            value = Activator.CreateInstance(typeof(T));
                            _classContainer[typeof(T)] = Tuple.Create(result.Item1, value);
                        }
                        return (T)value;
                    }
                    else
                    {

                        return (T)Activator.CreateInstance(typeof(T));
                    }
                }
            }
            
            throw new InvalidOperationException("Brak rejestracji podanej klasy");
        }

        public void BuildUp<T>(T instance)
        {
            throw new NotImplementedException();
        }
    }
}
