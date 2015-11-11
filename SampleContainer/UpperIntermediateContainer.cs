using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SampleContainer
{
    public class UpperIntermediateContainer : IContainer
    {
        private Dictionary<Type, Tuple<bool, object>> _classContainer;
        private Dictionary<Type, Tuple<bool, Type, object>> _interfaceContainer;

        public UpperIntermediateContainer()
        {
            _classContainer = new Dictionary<Type, Tuple<bool, object>>();
            _interfaceContainer = new Dictionary<Type, Tuple<bool, Type, object>>();
        }

        #region IContainer

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
            Dictionary<Type, bool> resolvedTypes = new Dictionary<Type, bool>();
            var instance = (T)Resolve(typeof(T), resolvedTypes);
            resolvedTypes = null;
            return instance;
        }

        public void BuildUp<T>(T instance)
        {
            Dictionary<Type, bool> resolvedTypes = new Dictionary<Type, bool>();
            ResolveProperty(instance, typeof(T), resolvedTypes);
            resolvedTypes = null;
        }

        #endregion


        #region Private Methods

        private object Resolve(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            if (type.IsInterface)
            {
                if (_interfaceContainer.ContainsKey(type))
                {
                    var result = _interfaceContainer[type];
                    if (result.Item1)
                    {
                        object value = result.Item3;
                        if (value == null)
                        {
                            value = CreateInstance(result.Item2, resolvedTypes);
                            _interfaceContainer[type] = Tuple.Create(result.Item1, result.Item2, value);
                        }

                        return value;
                    }
                    else
                    {
                        return CreateInstance(result.Item2, resolvedTypes);
                    }
                }
            }
            else
            {
                if (_classContainer.ContainsKey(type))
                {
                    var result = _classContainer[type];
                    if (result.Item1)
                    {
                        object value = result.Item2;
                        if (value == null)
                        {
                            value = CreateInstance(type, resolvedTypes);
                            _classContainer[type] = Tuple.Create(result.Item1, value);
                        }

                        return value;
                    }
                    else
                    {
                        return CreateInstance(type, resolvedTypes);
                    }
                }
            }

            throw new InvalidOperationException("Brak rejestracji podanej klasy");
        }

        private object CreateInstance(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            CheckResolvingTypes(resolvedTypes, type);

            var allConstructors = type.GetConstructors();

            int maxParameter = -1;
            IEnumerable<ConstructorInfo> goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof(DependencyConstrutor), false).Any());
            if (!goodConstructors.Any())
            {
                maxParameter = allConstructors.Max(c => c.GetParameters().Count());
                goodConstructors = allConstructors.Where(c => c.GetParameters().Count() == maxParameter);
            }

            if (goodConstructors.Count() == 1)
            {
                var constructor = goodConstructors.First();
                var consParameters = constructor.GetParameters().ToList();
                if (maxParameter == -1)
                {
                    maxParameter = consParameters.Count;
                }

                object[] parameters = new object[maxParameter];
                for (int i = 0; i < maxParameter; i++)
                {
                    parameters[i] = Resolve(consParameters[i].ParameterType, resolvedTypes);
                }
                var obj = constructor.Invoke(parameters);

                resolvedTypes[type] = true;

                ResolveProperty(obj, type, resolvedTypes);

                return obj;
            }
            else
            {
                throw new InvalidOperationException("Brak odpowiedniego konstruktora");
            }
        }

        private void ResolveProperty(object obj, Type type, Dictionary<Type, bool> resolvedTypes)
        {
            var properties = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null);

            foreach (var property in properties)
            {
                property.SetValue(obj, Resolve(property.PropertyType, resolvedTypes));
            }
        }

        private void CheckResolvingTypes(Dictionary<Type, bool> resolvedTypes, Type type)
        {
            if (resolvedTypes.ContainsKey(type))
            {
                if (!resolvedTypes[type])
                {
                    throw new InvalidOperationException("Cycle in class " + type.ToString());
                }
            }
            else
            {
                resolvedTypes.Add(type, false);
            }
        }

        #endregion
    }
}
